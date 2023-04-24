using DockerBase.controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DockerBase.view
{
    public partial class MenuView : Form
    {
        private MenuController controller;
        public MenuView()
        {
            InitializeComponent();
            controller = new MenuController(this);
            Load += MenuScene_Load;
        }
        private void MenuScene_Load(object sender, EventArgs e)
        {
            controller.LoadContainers();
        }
        public void ShowNoContainersFound()
        {
            this.MenuFormLoader.Controls.Clear();
            NoContainersView noContainersFound = new NoContainersView(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            noContainersFound.FormBorderStyle = FormBorderStyle.None;
            this.MenuFormLoader.Controls.Add(noContainersFound);
            noContainersFound.Show();
        }
        public void ShowContainers()
        {
            MessageBox.Show("there are containers");
        }
        //create getter and setter for menuformloader
        public Panel GetMenuFormLoader()
        {
            return MenuFormLoader;
        }
    }
}
