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
        DockerService service = new DockerService();
        public MenuScene()
        {
            InitializeComponent();    
            service.CreateMySQLImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.CreateDockerContainer("5504", "password", "test");
        }
    }
}
