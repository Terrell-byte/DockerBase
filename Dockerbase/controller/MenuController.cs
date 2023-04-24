using DockerBase.model;
using DockerBase.view;

namespace DockerBase.controller
{
    public class MenuController
    {
        private DockerService docker = new DockerService();
        private MenuView view;
        public MenuController(MenuView view)
        {
            this.view = view;
        }
        public async void LoadContainers()
        {
            Dictionary<string, bool> containers = await docker.GetContainers();
            if (containers == null)
            {
                view.ShowNoContainersFound();
            }
            else
            {
                view.ShowContainers();
            }
        }
        public void CreateNewDatabaseTab(string name)
        {
            //create a UI element 
        }
    }
}
