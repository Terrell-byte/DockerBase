using Docker.DotNet;
using Docker.DotNet.Models;
using DockerBase.controller;
using DockerBase.view;

namespace DockerBase.model
{
    public class DockerModel
    {
        public DockerClient dockerClient;
        public List<Dictionary<string, string>> containerList = new List<Dictionary<string, string>>();
        private CancellationTokenSource cts;
        private static DockerModel? instance;

        public DockerModel()
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

        public static DockerModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DockerModel();
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

        public async Task<Dictionary<int, bool>> GetUsedHostPortsAsync()
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
            cts = new CancellationTokenSource();
            await UpdateContainersList(cts.Token);
        }

        public void Stop()
        {
            cts.Cancel();
        }

        private async Task UpdateContainersList(CancellationToken token)
        {
            MenuController menuController = new MenuController(MenuView.Instance);
            while (!token.IsCancellationRequested)
            {
                try
                {
                    // Check the cancellation token
                    token.ThrowIfCancellationRequested();

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
                        menuController.RemoveDeletedContainers(containerList, MenuView.Instance.initializedTabs);
                    }
                    containerList = newContainerList;
                    menuController.RemoveDeletedContainers(containerList, MenuView.Instance.initializedTabs);
                }
                catch (OperationCanceledException)
                {
                    // The cancellation token was cancelled, exit the loop
                    break;
                }
                catch (Exception ex)
                {
                    // Log the exception and retry after a minute
                    Console.WriteLine($"Error while updating container list: {ex.Message}");
                    await Task.Delay(TimeSpan.FromSeconds(5), token);
                }
            }
        }
    }
}
