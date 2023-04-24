using DockerBase.model;

namespace DockerBase.view
{
    public partial class CreateDatabaseView : Form
    {
        private DockerService service = new DockerService();

        private MenuView menuScene;
        public CreateDatabaseView(MenuView menuScene)
        {
            InitializeComponent();
            this.menuScene = menuScene;
            _ = service.CreateMySQLImage();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createDatabaseButton_Click(object sender, EventArgs e)
        {
            String name = nameField.Text;
            _ = service.CreateDockerContainerAsync("rootpassword123", name);
            menuScene.GetMenuFormLoader().Controls.Clear();
            this.Close();
        }

    }
}
