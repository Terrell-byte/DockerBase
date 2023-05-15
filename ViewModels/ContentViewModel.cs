using Docker.DotNet.Models;
using DockerbaseWPF.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private string _entryCount;
        private bool _isViewVisible = true;
        private string _containerState = "Stop";
        private string _username;
        private string _password;
        private ContentModel _contentModel = new ContentModel();
        private DockerViewModel _docker = new DockerViewModel();
        private DatabaseService _databaseService = new DatabaseService();

        //ICommands
        public ICommand DeleteContainer { get; }
        public ICommand SetContainerState { get; }
        public ICommand InsertIntoDatabase { get; }

        //Constructor
        public ContentViewModel (string focusedContainer)
        {
            _focusedContainer = focusedContainer;
            DeleteContainer = new RelayCommand(ExecuteDeleteContainer);
            InsertIntoDatabase = new RelayCommand(ExecuteInsertIntoDatabase);
        }


        //Methods
        public async Task InitializeAsync()
        {
            await SetFocusedContainerAsync();
        }
        private async Task SetFocusedContainerAsync()
        {
            _container = await _contentModel.GetContainerByNameAsync(_focusedContainer);
            await PopulateDataGrid();
            await PopulateNewEntiesGrid();
            await GetEntryCount();

        }
        private async void ExecuteDeleteContainer(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Deleting Container...", "Please Wait", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                IsViewVisible = false;
            }
            await _contentModel.DeleteDockerContainerAsync(_container.Id);
        }

        private async void ExecuteInsertIntoDatabase(object obj)
        {
            var query = $"INSERT INTO userDB.users (username, password) VALUES ('{Username}', '{Password}');";
            var connectionString = BuildConnectionString();
            await _databaseService.ExecuteNonQueryAsync(connectionString, query);
        }

        private async Task GetEntryCount()
        {
            //lets connect to the database and then run a query to get the count of entries in the table
            var query = "SELECT COUNT(*) FROM userDB.users;";
            var connectionString = BuildConnectionString();
            EntryCount = (await _databaseService.FetchScalarFromDatabaseAsync(connectionString, query)).ToString();
        }


        private async Task PopulateNewEntiesGrid()
        {
            var quary = "SELECT id, date_added FROM userDB.users ORDER BY date_added DESC LIMIT 5;";
            var connectionString = BuildConnectionString();

            for (int retries = 0; retries < 5; retries++)
            {
                try
                {
                    await _databaseService.FetchDataFromDatabaseAsync(connectionString, quary);
                    _newEntriesDataGridContent = (DataView)await _databaseService.FetchDataFromDatabaseAsync(connectionString, quary);

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
                    await _databaseService.FetchDataFromDatabaseAsync(connectionString, quary);
                    _mainDataGridContent = (DataView)await _databaseService.FetchDataFromDatabaseAsync(connectionString, quary);
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
        public string EntryCount
        {
            get { return _entryCount; }
            set
            {
                if (value == _entryCount) return;
                _entryCount = value;
                OnPropertyChanged(nameof(EntryCount));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }
        public string ContainerState
        {
            get => _containerState;
            set
            {
                _containerState = value;
                OnPropertyChanged(nameof(ContainerState));
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

    }
}
