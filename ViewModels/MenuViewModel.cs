using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Docker.DotNet.Models;
using DockerbaseWPF.Models;
using DockerbaseWPF.Views;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DockerbaseWPF.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        //Variables
        private UserControl _contentView;
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public DockerViewModel DockerViewModel = new DockerViewModel();

        //ICommands
        public ICommand AddDatabaseCommand { get; }
        public ICommand CreateScrollViewerItem { get; }

        //Constructor
        public MenuViewModel()

        {
            AddDatabaseCommand = new RelayCommand(ExecuteAddDatabase);
            Messenger.Instance.DatabaseAdded += OnDatabaseAdded;
            FetchDockerbaseContainers();
        }

        //Methods
        private void OnDatabaseAdded(object sender, string databaseName)
        {
            Items.Add(databaseName);
        }

        private void ExecuteAddDatabase(object obj)
        {
            ContentView = new AddDatabase();
        }

        //This method is used make sure that we are displaying the Dockerbase containers in the menu ScrollViewer when the application is first launched
        private async Task FetchDockerbaseContainers()
        {
            var containers = await DockerViewModel.GetDockerbaseContainersAsync();

            foreach (var container in containers)
            {
                string containerName = container.Names.First().TrimStart('/');
                Items.Add(containerName);
            }
        }


        //Getters and Setters
        public UserControl ContentView
        {
            get => _contentView;
            set
            {
                _contentView = value;
                OnPropertyChanged(nameof(ContentView));
            }
        }

        public ObservableCollection<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }
}
