using DockerBase.model;
using DockerBase.view;

namespace DockerBase.controller
{
    public class MenuController
    {
        private MenuView view;
        public MenuController(MenuView view)
        {
            this.view = view;
        }
        public void LoadContainers(List<Dictionary<string, string>> containers)
        {
            if (containers.Count == 0)
            {
                DockerModel.Instance.Stop();
                view.ShowNoContainersFound();
            }
            else
            {
                view.ShowContainers(containers);
            }
        }

        public void RemoveDeletedContainers(List<Dictionary<string, string>> containers, List<DatabaseTab> initializedTabs)
        {
            var databaseList = MenuView.Instance.GetDatabaseList();
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
                    databaseList.Controls.Remove(initializedTab);
                    initializedTab.Close();
                    initializedTabs.RemoveAt(i);
                    LoadContainers(DockerModel.Instance.containerList);
                }
            }
        }
    }
}
