using DockerBase.model;
using DockerBase.view;

namespace DockerBase.controller
{
    public class MenuController
    {
        private DockerService docker = DockerService.Instance;
        private MenuView view;
        public MenuController(MenuView view)
        {

            this.view = view;
        }
        public async void LoadContainers(List<Dictionary<string, string>> containers)
        {
            if (containers.Count == 0)
            {
                view.ShowNoContainersFound();
            }
            else
            {
                view.ShowContainers(containers);
            }
        }
    }
}
