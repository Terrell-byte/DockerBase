﻿using Docker.DotNet;
using Docker.DotNet.Models;

namespace DockerBase
{
    public class DockerService
    {
        private readonly DockerClient DockerClient;

        public DockerService()
        {
            if (OperatingSystem.IsWindows())
            {
                DockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            }
            else if (OperatingSystem.IsLinux())
            {
                DockerClient = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();
            }
            else
            {
                throw new Exception("unknown operation system");
            }
        }

        public async Task CreateMySQLImage()
        {
            var imageCreateParameters = new ImagesCreateParameters
            {
                FromImage = "mysql",
                Tag = "latest"
            };

            await DockerClient.Images.CreateImageAsync(imageCreateParameters, null, new Progress<JSONMessage>(), CancellationToken.None);
        }
        public async Task CreateDockerContainer(string password, string name)
        {
            // Retrieve a list of currently bound host ports
            var usedPorts = await GetUsedHostPorts();

            // Find the next available port number
            int port = 1;
            while (usedPorts.ContainsKey(port))
            {
                port++;
            }

            if (name == "")
            {
                MessageBox.Show("Error 002: Database must have a name");
                return;
            }

            // Create the container with the next available port
            var containerCreateParameters = new CreateContainerParameters
            {
                Image = "mysql",
                Name = name,
                Env = new List<string> { "MYSQL_ROOT_PASSWORD=" + password },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { "3306/tcp", new List<PortBinding> { new PortBinding { HostPort = $"{port}/tcp" } } }
                    }
                }
            };
            await DockerClient.Containers.CreateContainerAsync(containerCreateParameters);
            //now let us start the container
            await DockerClient.Containers.StartContainerAsync(name, new ContainerStartParameters());
        }

        private async Task<Dictionary<int, bool>> GetUsedHostPorts()
        {
            var usedPorts = new Dictionary<int, bool>();
            var containers = await DockerClient.Containers.ListContainersAsync(
                new ContainersListParameters { All = true });
            foreach (var container in containers)
            {
                foreach (var port in container.Ports)
                {
                    if (port.PublicPort > 0 && !usedPorts.TryGetValue(port.PublicPort, out _))
                    {
                        usedPorts.Add(port.PublicPort, true);
                    }
                }
            }
            return usedPorts;
        }
    }
}
