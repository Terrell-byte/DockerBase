using DockerBase.controller;
using DockerBase.model;

namespace DockerBase.view
{
    public partial class MenuView : Form
    {
        private MenuController menuController;
        private DatabaseTabController databaseTabController;
        private DockerService docker = DockerService.Instance;
        public MenuView()
        {
            InitializeComponent();
            menuController = new MenuController(this);
            databaseTabController = new DatabaseTabController(this);
            Load += MenuScene_Load;
        }
        public async void MenuScene_Load(object sender, EventArgs e)
        {
            // Start the service
            docker.Start();

            await Task.Delay(2000);

            // Load the containers
            menuController.LoadContainers(docker.containerList);
        }

        public void ShowNoContainersFound()
        {
            this.MenuFormLoader.Controls.Clear();
            NoContainersView noContainersFound = new NoContainersView(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            noContainersFound.FormBorderStyle = FormBorderStyle.None;
            this.MenuFormLoader.Controls.Add(noContainersFound);
            noContainersFound.Show();
        }
        public async Task ShowContainers(List<Dictionary<string, string>> containers)
        {
            this.DatabaseList.Controls.Clear();
    
            foreach (var container in containers)
            {
                var databaseTab = new DatabaseTab()
                {
                    Dock = DockStyle.Top,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None,
                };
                databaseTabController.SetTabName(databaseTab, container["Name"]);
                this.DatabaseList.Controls.Add(databaseTab);
                databaseTab.Show();
            }
        }


        public Panel GetMenuFormLoader()
        {
            return MenuFormLoader;
        }
        public Panel GetDatabaseList()
        {
            return DatabaseList;
        }
    }
}
