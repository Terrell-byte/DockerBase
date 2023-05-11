﻿using Docker.DotNet.Models;
using DockerbaseWPF.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DockerbaseWPF.ViewModels
{
    public class ContentViewModel : ViewModelBase
    {
        //variables
        private string _focusedContainer;
        private DockerViewModel _dockerViewModel;
        private ContainerModel _container;
        private DataView _mainDataGridContent;

        //Constructor
        public ContentViewModel(string focusedContainer)
        {
            _focusedContainer = focusedContainer;
            _dockerViewModel = new DockerViewModel();
        }


        //Methods
        public async Task InitializeAsync()
        {
            await SetFocusedContainerAsync();
            PopulateDataGrid();
        }
        private async Task SetFocusedContainerAsync()
        {
            _container = await GetContainerByNameAsync(_focusedContainer);
            PopulateDataGrid();
        }
        private async void PopulateDataGrid()
        {
            var connectionString = $"server=127.0.0.1;port={_container.Port};user=root;password={_container.Password};";
            bool connected = false;
            int retries = 0;

            while (!connected && retries < 5)
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        using (MySqlCommand command = new MySqlCommand("SELECT * FROM userDB.users;", connection))
                        {
                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                            {
                                DataTable table = new DataTable();
                                await Task.Run(() => adapter.Fill(table));
                                _mainDataGridContent = table.DefaultView;
                            }
                        }

                        connected = true;
                    }
                }
                catch (MySqlException ex)
                {
                    // If it's a connection issue, wait for a bit and then retry.
                    if (ex.Number == 1042 || ex.Number == 0)
                    {
                        retries++;
                        await Task.Delay(1000);
                    }
                    else
                    {
                        // If it's another issue, rethrow the exception.
                        throw;
                    }
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
    }
}
