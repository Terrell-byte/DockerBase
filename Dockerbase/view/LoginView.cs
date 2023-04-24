using DockerBase;
using DockerBase.controller;
using DockerBase.model;

namespace DockerBase.view
{
    public partial class LoginView : Form
    {

        public LoginView()
        {
            InitializeComponent();
            controller = new LoginController(this, new UserModel());
        }

        public string Username
        {
            get { return usernameField.Text; }
            set { usernameField.Text = value; }
        }

        public string Password
        {
            get { return passwordField.Text; }
            set { passwordField.Text = value; }
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            controller.LoginBtn_Event(sender, e);
        }
    }
}