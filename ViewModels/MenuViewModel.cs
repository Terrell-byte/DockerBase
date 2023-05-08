using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using DockerbaseWPF.Views;
using System.Windows;

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
            Timer containerUpdateTimer = new Timer(1000);
            containerUpdateTimer.Elapsed += async (sender, e) => await Task.Run(FetchDockerbaseContainers);
            containerUpdateTimer.AutoReset = true;
            containerUpdateTimer.Enabled = true;
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
            Application.Current.Dispatcher.Invoke(() =>
            {
                // Clear the current list of Items
                Items.Clear();

                // Add the containers to the Items collection
                foreach (var container in containers)
                {
                    Items.Add(container.Names.First().Substring(1));
                }
            });
        }


        //lets open the ContentView and pass the name of the container that is in focus so that all the information about that container can be displayed
        private void CurrentContainerInFocus(string name)
        {
            throw new NotImplementedException();
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
