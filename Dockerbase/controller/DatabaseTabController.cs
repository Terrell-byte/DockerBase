using DockerBase.view;

namespace DockerBase.controller
{
    internal class DatabaseTabController
    {
        private MenuView menuView;

        public DatabaseTabController(MenuView view)
        {
            this.menuView = view;
        }

        public DatabaseTabController()
        {
        }

        // set the text in the button to the name of the database
        public void SetTabName(DatabaseTab databaseTab, string name)
        {
            databaseTab.DatabaseName = name;
        }

        public void focusTab(DatabaseTab databaseTab)
        {
            //lets get the name of the database
            string name = databaseTab.DatabaseName;
            ContentController content = new ContentController();
            //lets get the name and port of the database in the docker container
            ContentView.Instance.LoadData("rootpassword", "3306");
            MenuView.Instance.SetContent(ContentView.Instance);
        }

    }
}
