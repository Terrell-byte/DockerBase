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
        //Create Database User Controls
        private string _containerName;
        private string _ContainerPassword;
        private ObservableCollection<string> _databaseTypes;
        private string _selectedDatabaseType;
        private ObservableCollection<string> _databaseTemplates;
        private string _selectedDatabaseTemplate;
        private string _errorMessage;
        private bool _isViewVisible = true;
        private bool _showDatabaseType;
        private UserControl _contentView;


        DockerViewModel DockerViewModel = new DockerViewModel();

        public UserControl ContentView
        {
            get => _contentView;
            set
            {
                _contentView = value;
                OnPropertyChanged(nameof(ContentView));
            }
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

        //ICommands
        public ICommand AddDatabaseCommand { get; }
        public ICommand CreateDatabaseCommand { get; }
        public ICommand ToggleDatabaseTypeCommand { get; }



        public MenuViewModel()
        {
            AddDatabaseCommand = new RelayCommand(ExecuteAddDatabase);
            CreateDatabaseCommand = new RelayCommand(ExecuteCreateDatabase, CanExcuteCreateDatabase);
            ToggleDatabaseTypeCommand = new RelayCommand(ToggleDatabaseType);

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

        private void ExecuteCreateDatabase(object obj)
        {
            if ((Password.Length > 8 && Regex.IsMatch(Password, @"\d") || Regex.IsMatch(Password, @"[!%?@#$^&*]")))
            {
                Task.Run(async () =>
                {
                    await DockerViewModel.CreateDockerContainerAsync(Name, Password, SelectedDatabaseTemplate, SelectedDatabaseType);
                });
                //lets close the User Control and show the main view
                IsViewVisible = false;
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
            else if (string.IsNullOrEmpty(Password) )
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

        private async void ExecuteDeleteContainer(object obj)
        {
            if (obj is Button containerButton)
            {
                string containerId = (string)containerButton.Tag;
                await DockerViewModel.DeleteDockerContainerAsync(containerId);
            }
        }


        //lets check if we can add a database with the given information
        private void ExecuteAddDatabase(object obj)
        {
            ContentView = new AddDatabase();
        }

        private void ToggleDatabaseType(object obj)
        {
            ShowDatabaseType = !ShowDatabaseType;
        }
    }
}
