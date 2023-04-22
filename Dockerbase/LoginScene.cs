using DockerBase;

namespace DockerBase
{
    public partial class LoginScene : Form
    {
        UserDB userDB = new UserDB();

        public LoginScene()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;

            if (userDB.ValidateUser(username, password) == true)
            {
                MessageBox.Show("Login successful!");
                new MenuScene().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
                usernameField.Text = null;
                passwordField.Text = null;
            }
        }
    }
}