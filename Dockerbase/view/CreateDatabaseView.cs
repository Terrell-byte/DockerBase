using DockerBase.model;
using DockerBase.controller;

namespace DockerBase.view
{
    public partial class CreateDatabaseView : Form
    {
        private DockerService docker = new DockerService();

        private MenuView view;
        private DatabaseTabController controller;
        private DatabaseTab databaseView;
        public CreateDatabaseView(MenuView menuView)
        {
            InitializeComponent();
            this.view = menuView;
            _ = docker.CreateMySQLImage();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createDatabaseButton_Click(object sender, EventArgs e)
        {
            String name = nameField.Text;
            _ = docker.CreateDockerContainerAsync("rootpassword123", name);
            view.GetMenuFormLoader().Controls.Clear();
            view.ShowContainers();

            this.Close();
        }

    }
}
