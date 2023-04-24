﻿using Docker.DotNet.Models;
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
            Load += MenuScene_Load;
        }

        private async void MenuScene_Load(object sender, EventArgs e)
        {
            if (await GetContainers() == false)
            {
                this.MenuFormLoader.Controls.Clear();
                NoContainersFound noContainersFound = new NoContainersFound(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                noContainersFound.FormBorderStyle = FormBorderStyle.None;
                this.MenuFormLoader.Controls.Add(noContainersFound);
                noContainersFound.Show();
            }
            else
            {
                MessageBox.Show("there are containers");
            }
        }
        public async Task<bool> GetContainers()
        {
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
                            CreateNewDatabaseTab(name);
                            await dockerClient.Containers.StartContainerAsync(name, new ContainerStartParameters());
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //create getter and setter for menuformloader
        public Panel GetMenuFormLoader()
        {
            return MenuFormLoader;
        }

        public void CreateNewDatabaseTab(string name)
        {
            //create a UI element 
        }
    }
}