using DockerBase;

namespace DockerBase
{
    public partial class LoginScene : Form
    {
        DockerService dockerService = new DockerService();
        UserDB userDB = new UserDB();

        public LoginScene()
        {
            InitializeComponent();
        }
        private async void LoginScene_load(object sender, EventArgs e)
        {
            await dockerService.StartCompose();
        }

        private void loginLogo(object sender, EventArgs e)
        {

        }

        private void loginTitle(object sender, EventArgs e)
        {

        }

        private void passwordIcon(object sender, EventArgs e)
        {

        }

        private void usernameIcon(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usernameField_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;

            if (userDB.ValidateUser(username, password) == true)
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }

        }
    }
}