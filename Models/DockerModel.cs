using Docker.DotNet;
using Docker.DotNet.Models;
using DockerbaseWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DockerbaseWPF.Models
{
    public class DockerModel
    {
        public DockerClient dockerClient;
        public List<Dictionary<string, string>> containerList = new List<Dictionary<string, string>>();
        private bool isRunning = false;

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

        public async void UpdateContainersList(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var containers = await GetDockerbaseContainersAsync();
                    var newContainerList = BuildContainerInfoList(containers);
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while updating container list: {ex.Message}");
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }
        }
        private async Task<IEnumerable<ContainerListResponse>> GetDockerbaseContainersAsync()
        {
            var containers = await dockerClient.Containers.ListContainersAsync(
                new ContainersListParameters { All = true });

            return containers.Where(c => c.Labels.Any(l => l.Value.Contains("Dockerbase")));
        }

        private List<Dictionary<string, string>> BuildContainerInfoList(IEnumerable<ContainerListResponse> containers)
        {
            var containerInfoList = new List<Dictionary<string, string>>();

            foreach (var container in containers)
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

                containerInfoList.Add(containerInfo);
            }
            return containerInfoList;
        }
    }
}
