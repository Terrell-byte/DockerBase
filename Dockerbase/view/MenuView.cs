using DockerBase.controller;
using DockerBase.model;

namespace DockerBase.view
{
    public partial class MenuView : Form
    {
        private MenuController menuController;
        private DatabaseTabController databaseTabController;
        private DockerService docker = DockerService.Instance;
        public List<DatabaseTab> initializedTabs = new List<DatabaseTab>();
        //lets make this a singleton class
        private static MenuView instance;
        public static MenuView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MenuView();
                }
                return instance;
            }
        }
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
            //here we need to create a createNewDatabase button
            AddDatabaseButton createNewDatabaseButton = new AddDatabaseButton() { Dock = DockStyle.Top, TopLevel = false, TopMost = true };
            this.DatabaseList.Controls.Add(createNewDatabaseButton);
            createNewDatabaseButton.Show();
            foreach (var container in containers)
            {
                string containerName = container["Name"];

                var databaseTab = new DatabaseTab()
                {
                    Dock = DockStyle.Top,
                    TopLevel = false,
                    TopMost = true,
                    FormBorderStyle = FormBorderStyle.None,
                };

                databaseTabController.SetTabName(databaseTab, containerName);
                this.DatabaseList.Controls.Add(databaseTab);
                databaseTab.Show();
                initializedTabs.Add(databaseTab);
            }
        }


        public void RemoveDeletedContainers(List<Dictionary<string, string>> containers, List<DatabaseTab> initializedTabs)
        {
            List<string> containerNames = new List<string>();
            foreach (var container in containers)
            {
                containerNames.Add(container["Name"]);
            }

            for (int i = initializedTabs.Count - 1; i >= 0; i--)
            {
                var initializedTab = initializedTabs[i];
                if (!containerNames.Contains(initializedTab.DatabaseName))
                {
                    this.DatabaseList.Controls.Remove(initializedTab);
                    initializedTab.Close();
                    initializedTabs.RemoveAt(i);
                    menuController.LoadContainers(docker.containerList);
                }
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
