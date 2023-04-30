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
            this.Load += CreateDatabaseView_Load;
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
        private void CreateDatabaseView_Load(object sender, EventArgs e)
        {
            containerType.Items.Add("AuthDB");
        }

        private void containerType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void createDatabaseButton_Click(object sender, EventArgs e)
        {
            String name = nameField.Text;
            //create a condition if it is empty
            string selectedType = containerType.SelectedItem.ToString();
            await dockerController.CreateDockerContainerAsync("rootpassword123", name, selectedType);
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
