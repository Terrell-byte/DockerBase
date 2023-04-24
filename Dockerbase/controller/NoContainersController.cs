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
        private MenuView menu;
        private CreateDatabaseView createDatabase;

        public NoContainersController(MenuView menu, CreateDatabaseView createDatabase)
        {
            this.menu = menu;
            this.createDatabase = createDatabase;
        }

        public void AddDatabase_Event(object sender, EventArgs e)
        {
            new CreateDatabaseView(menu).Show();
        }
    }
}
