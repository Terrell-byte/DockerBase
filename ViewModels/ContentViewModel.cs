using Docker.DotNet.Models;
using DockerbaseWPF.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DockerbaseWPF.ViewModels
{
    public class ContentViewModel : ViewModelBase
    {
        //variables
        private string _focusedContainer;
        private DockerViewModel _dockerViewModel;
        private ContainerModel _container;
        private DataView _mainDataGridContent;
        private DataView _newEntriesDataGridContent;

        //Constructor
        public ContentViewModel(string focusedContainer)
        {
            _focusedContainer = focusedContainer;
            _dockerViewModel = new DockerViewModel();
        }


        //Methods

        // ALL OF THIS CODE NEEDS TO BE REFAORED AND CLEAN UP!!!!!
        public async Task InitializeAsync()
        {
            await SetFocusedContainerAsync();
            await PopulateDataGrid();
            await PopulateNewEntiesGrid();
        }
        private async Task SetFocusedContainerAsync()
        {
            _container = await GetContainerByNameAsync(_focusedContainer);
            await PopulateDataGrid();
            await PopulateNewEntiesGrid();
        }

        private async Task PopulateNewEntiesGrid()
        {
            var quary = "SELECT id, date_added FROM userDB.users;";
            var connectionString = BuildConnectionString();

            for (int retries = 0; retries < 5; retries++)
            {
                try
                {
                    await FetchDataFromDatabase(connectionString, quary);
                    _newEntriesDataGridContent = await FetchDataFromDatabase(connectionString, quary);

                    break;
                }
                catch (MySqlException ex) when (ex.Number == 1042 || ex.Number == 0)
                {
                    // If it's a connection issue, wait for a bit and then retry.
                    await Task.Delay(1000);
                }
            }
        }
        private async Task PopulateDataGrid()
        {
            var quary = "SELECT * FROM userDB.users;";
            var connectionString = BuildConnectionString();

            for (int retries = 0; retries < 5; retries++)
            {
                try
                {
                    await FetchDataFromDatabase(connectionString, quary);
                    _mainDataGridContent = await FetchDataFromDatabase(connectionString, quary);
                    break;
                }
                catch (MySqlException ex) when (ex.Number == 1042 || ex.Number == 0)
                {
                    // If it's a connection issue, wait for a bit and then retry.
                    await Task.Delay(1000);
                }
            }
        }

        private string BuildConnectionString()
        {
            return $"server=127.0.0.1;port={_container.Port};user=root;password={_container.Password};";
        }

        private async Task<DataView> FetchDataFromDatabase(string connectionString, string quary)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var table = await FetchTableData(connection, quary);
                return table.DefaultView;
            }
        }

        private async Task<DataTable> FetchTableData(MySqlConnection connection, string quary)
        {
            using (MySqlCommand command = new MySqlCommand(quary, connection))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    var table = new DataTable();
                    await Task.Run(() => adapter.Fill(table));
                    return table;
                }
            }
        }


        public async Task<ContainerModel> GetContainerByNameAsync(string containerName)
        {
            // Fetch the list of containers
            var containers = await _dockerViewModel.GetDockerbaseContainersAsync();

            // Find the container with the given name
            var container = containers.FirstOrDefault(c => c.Names.Any(n => n.Substring(1) == containerName));

            if (container != null)
            {
                // Map the Docker.DotNet container object to your Container class
                return new ContainerModel(
                    containerName,
                    container.Image,
                    container.Status,
                    container.Ports.First<Port>().PublicPort.ToString(),
                    container.Created.ToString(),
                    container.SizeRootFs.ToString(),
                    container.Labels["password"]
                );
            }

            return null;
        }
        //Getters and Setters
        public string FocusedContainer
        {
            get { return _focusedContainer; }
            set
            {
                if (value == _focusedContainer) return;
                _focusedContainer = value;
                OnPropertyChanged(nameof(FocusedContainer));
            }
        }
        public DataView MainDataGridContent
        {
            get { return _mainDataGridContent; }
            set
            {
                if (Equals(value, _mainDataGridContent)) return;
                _mainDataGridContent = value;
                OnPropertyChanged(nameof(MainDataGridContent));
            }
        }
        public DataView NewEntriesDataGridContent
        {
            get { return _newEntriesDataGridContent; }
            set
            {
                if (Equals(value, _newEntriesDataGridContent)) return;
                _newEntriesDataGridContent = value;
                OnPropertyChanged(nameof(NewEntriesDataGridContent));
            }
        }
    }
}
