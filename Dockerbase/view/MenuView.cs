using DockerBase.controller;
using DockerBase.model;
using Org.BouncyCastle.Asn1.BC;

namespace DockerBase.view
{
    public partial class MenuView : Form
    {
        private MenuController menuController;
        private DatabaseTabController databaseTabController;
        private DockerController dockerController = new DockerController(DockerModel.Instance);
        public List<DatabaseTab> initializedTabs = new List<DatabaseTab>();
        //lets make this a singleton class
        private static MenuView? instance;
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
            _ = DockerModel.Instance.Start();

            await Task.Delay(2000);

            // Load the containers
            menuController.LoadContainers(DockerModel.Instance.containerList);
            //lets get the username from the login view that is not a singleton class

            var username = LoginView.Instance.Username;
            this.usernameTitle.Text = username;
        }

        public void ShowNoContainersFound()
        {
            this.MenuFormLoader.Controls.Clear();
            NoContainersView noContainersFound = new NoContainersView(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            noContainersFound.FormBorderStyle = FormBorderStyle.None;
            this.MenuFormLoader.Controls.Add(noContainersFound);
            noContainersFound.Show();
        }
        public void ShowContainers(List<Dictionary<string, string>> containers)
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

        public void SetContent(ContentView contentView)
        {
            //lets load the ContentView to the MenuFormLoader
            this.MenuFormLoader.Controls.Clear();
            this.MenuFormLoader.Controls.Add(contentView);
            contentView.Show();

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
