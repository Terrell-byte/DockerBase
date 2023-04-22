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
    public partial class CreateDB : Form
    {
        DockerService service = new DockerService();
        public CreateDB()
        {
            InitializeComponent();
            service.CreateMySQLImage();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void createDatabaseButton_Click(object sender, EventArgs e)
        {
            String name = nameField.Text;
            _ = service.CreateDockerContainer("rootpassword123", name);
        }
    }
}
