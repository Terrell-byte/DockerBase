using DockerbaseWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DockerbaseWPF.Views
{
    /// <summary>
    /// Interaction logic for UserLoginView.xaml
    /// </summary>
    public partial class UserLoginView : Window
    {
        public UserLoginView()
        {
            InitializeComponent();
        }

        internal LoginViewModel LoginViewModel
        {
            get => default;
            set
            {
            }
        }

        /*
        This method is not true MVVM, as it is a code behind method, but 
        it is the easiest way to get the password from the password box
        without having to create a custom password box class.
         */
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = passwordField.Password;
            }
        }
    }
}
