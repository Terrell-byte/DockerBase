using Docker.DotNet.Models;
using Docker.DotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DockerBase
{
    public partial class MenuScene : Form
    {
        public MenuScene()
        {
            InitializeComponent();
            _ = StartAllContainers();
        }

        public async Task<object?> StartAllContainers()
        {

            //lets start all the containers that have the label Dockerbase
            // Retrieve the DockerClient instance from the DockerService singleton
            var dockerClient = DockerService.GetInstance().DockerClient;

            // Check if there are containers with the Dockerbase label
            var containers = await dockerClient.Containers.ListContainersAsync(
                new ContainersListParameters { All = true });

            if (containers.Any(c => c.Labels.Any(l => l.Value.Contains("Dockerbase"))))
            {
                // Start all containers with the Dockerbase label

                foreach (var container in containers)
                {
                    foreach (var label in container.Labels)
                    {
                        if (label.Value.Contains("Dockerbase"))
                        {
                            var name = container.Names[0].Substring(1);
                            await dockerClient.Containers.StartContainerAsync(name, new ContainerStartParameters());
                        }
                    }
                }
            }
            // Return null if there are no containers with the Dockerbase label
            return null;
        }


        private void AddContainer_Click(object sender, EventArgs e)
        {
            new CreateDB().Show();
        }
    }
}
