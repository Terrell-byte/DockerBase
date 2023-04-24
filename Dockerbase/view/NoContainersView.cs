using System;
using System.Collections.Generic;
using System.ComponentModel;
using DockerBase.controller;
using DockerBase.model;
using DockerBase.view;

namespace DockerBase.view
{
    public partial class NoContainersView : Form
    {
        private MenuView view;
        private NoContainersController controller;
        private CreateDatabaseView createDatabase;
        public NoContainersView(MenuView menuScene)
        {
            InitializeComponent();
            controller = new NoContainersController(menuScene, createDatabase);
            view = menuScene;
        }

        private void AddDB_Click(object sender, EventArgs e)
        {
            controller.AddDatabase_Event(sender, e);
        }
    }
}
