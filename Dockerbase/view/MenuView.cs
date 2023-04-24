using DockerBase.controller;
using DockerBase.model;

namespace DockerBase.view
{
    public partial class MenuView : Form
    {
        private MenuController menuController;
        private DatabaseTabController databaseTabController;
        public MenuView()
        {
            InitializeComponent();
            menuController = new MenuController(this);
            databaseTabController = new DatabaseTabController(this);
            Load += MenuScene_Load;
        }
        private void MenuScene_Load(object sender, EventArgs e)
        {
            menuController.LoadContainers();
        }
        public void ShowNoContainersFound()
        {
            this.MenuFormLoader.Controls.Clear();
            NoContainersView noContainersFound = new NoContainersView(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            noContainersFound.FormBorderStyle = FormBorderStyle.None;
            this.MenuFormLoader.Controls.Add(noContainersFound);
            noContainersFound.Show();
        }
        public async void ShowContainers()
        {

            while (true)
            {
                var _docker = new DockerService();
                var _containers = await _docker.GetContainers();
                if (_containers != null)
                {
                    break;
                }
                await Task.Delay(1000);
            }
            DockerService docker = new DockerService();
            //get the containers using the getcontainers method
            Dictionary<string, bool> containers = await docker.GetContainers();
            //create new database form for each container
            this.DatabaseList.Controls.Clear();
            //first get the dockerservice instance

            //for each container we create a new DatabaseTab form
            foreach (KeyValuePair<string, bool> container in containers)
            {
                //create a new DatabaseTab form
                DatabaseTab databaseTab = new DatabaseTab() { Dock = DockStyle.Top, TopLevel = false, TopMost = true };
                //set the form border style to none
                databaseTab.FormBorderStyle = FormBorderStyle.None;
                // set the name of the database on the DatabaseTab form
                databaseTabController.SetTabName(databaseTab, container.Key);
                //add the form to the menuformloader
                this.DatabaseList.Controls.Add(databaseTab);
                //show the form
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
