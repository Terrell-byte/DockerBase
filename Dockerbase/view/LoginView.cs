using DockerBase;
using DockerBase.controller;
using DockerBase.model;

namespace DockerBase.view
{
    public partial class LoginView : Form
    {
        private static LoginView instance;

        public static LoginView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginView();
                }
                return instance;
            }
        }
        public LoginView()
        {
            InitializeComponent();
            controller = new LoginController(this, new LoginModel());
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