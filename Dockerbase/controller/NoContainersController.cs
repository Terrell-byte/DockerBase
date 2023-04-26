using DockerBase.model;
using DockerBase.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerBase.controller
{
    internal class NoContainersController
    {
        MenuView menu = MenuView.Instance;
        public NoContainersController()
        {

        }

        public void AddDatabase_Event(object sender, EventArgs e)
        {
            new CreateDatabaseView(menu).Show();
        }
    }
}
