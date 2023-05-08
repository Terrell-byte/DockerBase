using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DockerbaseWPF.Models;
using DockerbaseWPF.Views;

namespace DockerbaseWPF.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        LoginModel LoginModel = new LoginModel();

        public string Username 
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public string? Password 
        { 
            get => _password;
            set
            {
                _password = value;
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
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLoginCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrEmpty(Username) || Password == null)
                return false;
            else
            return true;
        }

        private void ExecuteLogin(object obj)
        {
            (string _username, string _password) = LoginModel.GetUserInfo(Username);
            if (_username != null && _password != null && Username == _username && Password == _password)
            {
                ErrorMessage = "";
                IsViewVisible = false;
                new MenuView().Show();                
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }
        }
    }
}
