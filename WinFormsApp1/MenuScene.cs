using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockerBase
{
    public partial class MenuScene : Form
    {

        public MenuScene()
        {
            InitializeComponent();
            //First start all containers with the label Dockerbase
            //then if there are no container then show button


        }

        private void AddContainer_Click(object sender, EventArgs e)
        {
            new CreateDB().Show();
        }
    }
}
