using Docker.DotNet;
using Docker.DotNet.Models;
using DockerBase.controller;
using DockerBase.view;
using MySqlX.XDevAPI;
using System.ComponentModel;
using System.Net.Sockets;

namespace DockerBase.model
{
    public class DockerService
    {
        private readonly DockerClient dockerClient;
        public List<Dictionary<string, string>> containerList = new List<Dictionary<string, string>>();
        private CancellationTokenSource cts = new CancellationTokenSource();
        private static DockerService instance;

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

        public static DockerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DockerService();
                }
                return instance;
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

        public async Task Start()
        {
            await UpdateContainersList(cts.Token);
        }

        public async Task Stop()
        {
            cts.Cancel();
        }

        private async Task UpdateContainersList(CancellationToken token)
        {
            var menuView = MenuView.Instance;
            MenuController menuController = new MenuController(menuView);
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var containers = await dockerClient.Containers.ListContainersAsync(
                        new ContainersListParameters { All = true });

                    var newContainerList = new List<Dictionary<string, string>>();

                    if (containers.Any(c => c.Labels.Any(l => l.Value.Contains("Dockerbase"))))
                    {
                        foreach (var container in containers)
                        {
                            if (container.Labels.Any(l => l.Value.Contains("Dockerbase")))
                            {
                                var containerInfo = new Dictionary<string, string>
                                {
                                    {"Name", container.Names[0]},
                                    {"ID", container.ID},
                                    {"Image", container.Image},
                                    {"Status", container.Status},
                                    {"State", container.State},
                                    {"Created", container.Created.ToString()},
                                    {"Ports", string.Join(", ", container.Ports.Select(p => $"{p.PrivatePort}:{p.PublicPort}"))},
                                    {"Labels", string.Join(", ", container.Labels.Select(l => $"{l.Key}={l.Value}"))}
                                };
                                newContainerList.Add(containerInfo);
                            }
                        }
                        containerList = newContainerList;
                        // Wait for a minute before updating the list again
                        await Task.Delay(TimeSpan.FromSeconds(1), token);
                        menuView.RemoveDeletedContainers(containerList, menuView.initializedTabs);
                    }
                    containerList = newContainerList;        
                    menuView.RemoveDeletedContainers(containerList, menuView.initializedTabs);
                }
                catch (Exception ex)
                {
                    // Log the exception and retry after a minute
                    Console.WriteLine($"Error while updating container list: {ex.Message}");
                    await Task.Delay(TimeSpan.FromSeconds(5), token);
                }
            }
        }

        public async Task<List<Dictionary<string, string>>> GetContainers()
        {
            return containerList;
        }

    }

    public class ContainerInfo
    {
        public string Name { get; set; }
        public int Port { get; set; }
    }
}
