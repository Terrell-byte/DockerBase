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
    public partial class ContentView : UserControl
    {
        private ContentController controller;
        private static ContentView? instance;

        public static ContentView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ContentView();
                }
                return instance;
            }
        }
        public ContentView()
        {
            InitializeComponent();
            controller = new ContentController();
        }

        private void ContentView_Load(object sender, EventArgs e)
        {

        }

        public void LoadData(string password, string port)
        {
            string _password = password;
            string _port = port;
            previewTables.DataSource = controller.DatabaseInfo(password, port);
            recentEntries.DataSource = controller.GetRecentEntries(password, port);
        }
    }
}
