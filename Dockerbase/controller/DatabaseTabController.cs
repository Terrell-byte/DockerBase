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

        // set the text in the button to the name of the database
        public void SetTabName(DatabaseTab databaseTab, string name)
        {
            databaseTab.DatabaseName = name;
        }
    }
}
