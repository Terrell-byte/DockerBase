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
        // Variables
        private UserControl _contentView;
        private ObservableCollection<string> _items = new ObservableCollection<string>();
        private string _loggedInUsername;
        public DockerViewModel DockerViewModel = new DockerViewModel();

        // ICommand
        public ICommand AddDatabaseCommand { get; }
        public ICommand FocusContainer { get; }

        // Constructor
        public MenuViewModel()
        {
            AddDatabaseCommand = new RelayCommand(ExecuteAddDatabase);
            FocusContainer = new RelayCommand(ExecuteCurrentContainerInFocus);

            Messenger.Instance.StringValueChanged += OnStringValueChanged;

            // This makes sure that our list of containers is updated every second
            Timer containerUpdateTimer = new Timer(1000);
            containerUpdateTimer.Elapsed += async (sender, e) => await Task.Run(FetchDockerbaseContainers);
            containerUpdateTimer.AutoReset = true;
            containerUpdateTimer.Enabled = true;
        }

        // Methods
        private void ExecuteCurrentContainerInFocus(object obj)
        {
            ContentView = new ContentView();
        }
        private void OnStringValueChanged(object sender, Messenger.StringEventArgs e)
        {
            if (e.Key == "Username")
            {
                LoggedInUsername = e.Value;
            }
            if (e.Key == "ContainerName")
            {
                Items.Add(e.Value);
            }
        }

        private void ExecuteAddDatabase(object obj)
        {
            ContentView = new AddDatabase();
        }

        private async Task FetchDockerbaseContainers()
        {
            var containers = await DockerViewModel.GetDockerbaseContainersAsync();

            // We need to use the dispatcher to update the UI as we are on a background thread
            Application.Current.Dispatcher.Invoke(() =>
            {
                Items.Clear();
                foreach (var container in containers)
                {
                    Items.Add(container.Names.First().Substring(1));
                }
            });
        }


        // Getters and Setters
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

        public string LoggedInUsername 
        { get => _loggedInUsername;
          set
            {
                _loggedInUsername = value;
                OnPropertyChanged(nameof(LoggedInUsername));
            }
        }
    }
}
