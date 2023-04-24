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
    public partial class NoContainersFound : Form
    {
        private MenuScene menuScene;
        public NoContainersFound(MenuScene menuScene)
        {
            InitializeComponent();
            this.menuScene = menuScene;
        }

        private void AddDB_Click(object sender, EventArgs e)
        {
            new CreateDB(menuScene).Show();
        }
    }
}
