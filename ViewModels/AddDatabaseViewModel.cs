using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DockerbaseWPF.ViewModels
{
    public class AddDatabaseViewModel : ViewModelBase
    {
        private string _containerName;
        private string _ContainerPassword;
        private ObservableCollection<string> _databaseTypes;
        private string _selectedDatabaseType;
        private ObservableCollection<string> _databaseTemplates;
        private string _selectedDatabaseTemplate;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _showDatabaseType;
        private bool _showDatabaseTemplate;
        DockerViewModel DockerViewModel = new DockerViewModel();

        //ICommands
        public ICommand CreateDatabaseCommand { get; }
        public ICommand ToggleDatabaseTypeCommand { get; }
        public ICommand CloseCommand { get; }


        //Constructor
        public AddDatabaseViewModel()
        {
            CreateDatabaseCommand = new RelayCommand(ExecuteCreateDatabase, CanExcuteCreateDatabase);
            ToggleDatabaseTypeCommand = new RelayCommand(ToggleDatabaseType);
            CloseCommand = new RelayCommand(ExecuteCloseCommand);

            DatabaseTypes = new ObservableCollection<string>
            {
                "mysql",
            };

            Templates = new ObservableCollection<string>
            {
                "User_Database",
            };
            SelectedDatabaseType = DatabaseTypes.FirstOrDefault();
        }
        private void ExecuteCloseCommand(object obj)
        {
            IsViewVisible = false;
        }

        private void ExecuteCreateDatabase(object obj)
        {
            if ((Password.Length > 8 && Regex.IsMatch(Password, @"\d") || Regex.IsMatch(Password, @"[!%?@#$^&*]")))
            {
                //run this on a background thread so we don't block the UI
                Task.Run(() => DockerViewModel.CreateDockerContainerAsync(Name, Password, SelectedDatabaseTemplate, SelectedDatabaseType));

                IsViewVisible = false;

                //lets now send our name to the main view so we can display it in the list of containers
                Messenger.Instance.Send("ContainerName", Name);
            }
            else
            {
                ErrorMessage = "Please enter a valid password for the database";
            }
        }

        private bool CanExcuteCreateDatabase(object obj)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(SelectedDatabaseTemplate))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ToggleDatabaseType(object obj)
        {
            ShowDatabaseType = !ShowDatabaseType;
        }

        public string Name
        {
            get => _containerName;
            set
            {
                _containerName = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Password
        {
            get => _ContainerPassword;
            set
            {
                _ContainerPassword = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
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

        public ObservableCollection<string> DatabaseTypes
        {
            get => _databaseTypes;
            set
            {
                _databaseTypes = value;
                OnPropertyChanged(nameof(DatabaseTypes));
            }
        }
        public ObservableCollection<string> Templates
        {
            get => _databaseTemplates;
            set
            {
                _databaseTemplates = value;
                OnPropertyChanged(nameof(Templates));
            }
        }
        public string SelectedDatabaseType
        {
            get => _selectedDatabaseType;
            set
            {
                _selectedDatabaseType = value;
                OnPropertyChanged(nameof(SelectedDatabaseType));
            }
        }
        public string SelectedDatabaseTemplate
        {
            get => _selectedDatabaseTemplate;
            set
            {
                _selectedDatabaseTemplate = value;
                OnPropertyChanged(nameof(SelectedDatabaseTemplate));
            }
        }

        public bool ShowDatabaseType
        {
            get => _showDatabaseType;
            set
            {
                _showDatabaseType = value;
                OnPropertyChanged(nameof(ShowDatabaseType));
            }
        }
    }
}
