using DockerBase.model;
using DockerBase.controller;

namespace DockerBase.view
{
    public partial class CreateDatabaseView : Form
    {
        private static CreateDatabaseView? instance;
        private DockerController dockerController = new DockerController(DockerModel.Instance);
        private static MenuView? view;
        public CreateDatabaseView(MenuView menuView)
        {
            InitializeComponent();
            DockerModel.Instance.Start();
            view = menuView;
        }

        public static CreateDatabaseView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreateDatabaseView(view);
                }
                return instance;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createDatabaseButton_Click(object sender, EventArgs e)
        {
            String name = nameField.Text;
            _ = dockerController.CreateDockerContainerAsync("rootpassword123", name);
            view.GetMenuFormLoader().Controls.Clear();
            view.MenuScene_Load(sender, e);
            this.Close();
        }
        public void ValidateParamenters(string name)
        {
            if (name.Length == 0)
            {
                MessageBox.Show("Please enter a name for the database");
                return;
            }
        }
    }
}
