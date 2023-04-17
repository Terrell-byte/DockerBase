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
            userDB.ConnectToDB("root", "rootpassword", "3306");
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

        private void usernameText_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

        }
    }
}