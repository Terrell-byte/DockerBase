using Docker.DotNet;
using Docker.DotNet.Models;
using MySqlX.XDevAPI;
using System;
using System.Threading;
using System.Threading.Tasks;



namespace DockerBase.model
{
    public class DockerService
    {
        private readonly DockerClient dockerClient;

        public DockerService()
        {
            if (OperatingSystem.IsWindows())
            {
                dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();

            }
            else if (OperatingSystem.IsLinux())
            {
                dockerClient = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient();
            }
            else
            {
                throw new Exception("Unknown operating system.");
            }
            
    }

        public async Task CreateMySQLImage()
        {
            var imageCreateParameters = new ImagesCreateParameters
            {
                FromImage = "mysql",
                Tag = "latest"
            };

            await dockerClient.Images.CreateImageAsync(imageCreateParameters, null, new Progress<JSONMessage>(), CancellationToken.None);
        }

        public async Task<ContainerInfo> CreateDockerContainerAsync(string password, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Database must have a name.", nameof(name));
            }

            // Retrieve a list of currently bound host ports
            var usedPorts = await GetUsedHostPortsAsync();

            // Find the next available port number
            int port = 1;
            while (usedPorts.ContainsKey(port))
            {
                port++;
            }

            // Create the container with the next available port
            var containerCreateParameters = new CreateContainerParameters
            {
                Image = "mysql",
                Name = name,
                Labels = new Dictionary<string, string>
                {
                    {"mysql", "Dockerbase"}
                },
                Env = new List<string> { "MYSQL_ROOT_PASSWORD=" + password },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { "3306/tcp", new List<PortBinding> { new PortBinding { HostPort = $"{port}/tcp" } } }
                    }
                }
            };

            var container = await dockerClient.Containers.CreateContainerAsync(containerCreateParameters);

            // Start the container
            await dockerClient.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());

            return new ContainerInfo
            {
                Name = name,
                Port = port
            };
        }

        private async Task<Dictionary<int, bool>> GetUsedHostPortsAsync()
        {
            var containers = await dockerClient.Containers.ListContainersAsync(
                new ContainersListParameters { All = true });

            var usedPorts = new Dictionary<int, bool>();

            foreach (var container in containers)
            {
                foreach (var port in container.Ports)
                {
                    if (port.PublicPort > 0 && !usedPorts.ContainsKey(port.PublicPort))
                    {
                        usedPorts.Add(port.PublicPort, true);
                    }
                }
            }

            return usedPorts;
        }
        public async Task<Dictionary<string, bool>> GetContainers()
        {
            var containers = await dockerClient.Containers.ListContainersAsync(
                new ContainersListParameters { All = true });

            var containerDict = new Dictionary<string, bool>();

            foreach (var container in containers)
            {
                if (containers.Any(c => c.Labels.Any(l => l.Value.Contains("Dockerbase"))))
                {
                    var name = container.Names[0].Substring(1);
                    var isRunning = container.State == "running";
                    containerDict.Add(name, isRunning);
                    return containerDict;
                }
            }
            return null;
        }
    }   

    public class ContainerInfo
    {
        public string Name { get; set; }
        public int Port { get; set; }
    }
}
