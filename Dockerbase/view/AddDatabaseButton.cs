using DockerBase.controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerBase.view
{
    public partial class AddDatabaseButton : Form
    {
        private NoContainersController controller = new NoContainersController();
        public AddDatabaseButton()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            controller.AddDatabase_Event(sender, e);
        }
    }
}
