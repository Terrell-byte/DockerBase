using Docker.DotNet.Models;
using DockerbaseWPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DockerbaseWPF.ViewModels
{
    public class DockerViewModel : ViewModelBase
    {
        private DockerModel _model = new DockerModel();

        public IEnumerable<object> DockerContainers { get; internal set; }

        public async Task<CreateContainerResponse> CreateDockerContainerAsync(string name, string password, string template, string type)
        {
            // Retrieve a list of currently bound host ports
            var usedPorts = await _model.GetUsedHostPortsAsync();

            // Find the next available port number
            int port = 1;
            while (usedPorts.ContainsKey(port))
            {
                port++;
            }

            // Copy the SQL file to the shared folder
            string sharedFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SharedFolder");
            Directory.CreateDirectory(sharedFolderPath);
            string sourceSqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", $"{template}.sql");
            string destinationSqlFilePath = Path.Combine(sharedFolderPath, $"{template}.sql");
            File.Copy(sourceSqlFilePath, destinationSqlFilePath, true);

            // Create the container with the next available port and mount the shared folder as a volume
            var containerCreateParameters = new CreateContainerParameters
            {
                Image = type,
                Name = name,
                Labels = new Dictionary<string, string>
                {
                    {"mysql", "Dockerbase"},
                    {"password", password}

                },
                Env = new List<string> { "MYSQL_ROOT_PASSWORD=" + password },
                HostConfig = new HostConfig
                {
                    Binds = new List<string> { $"{sharedFolderPath}:/docker-entrypoint-initdb.d" },
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { "3306/tcp", new List<PortBinding> { new PortBinding { HostPort = $"{port}/tcp" } } }
                    }
                }
            };
            var container = await _model.dockerClient.Containers.CreateContainerAsync(containerCreateParameters);

            // Start the container
            await _model.dockerClient.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());
            return container;
        }



        public async Task<IEnumerable<ContainerListResponse>> GetDockerbaseContainersAsync()
        {
            var containers = await _model.dockerClient.Containers.ListContainersAsync(
                new ContainersListParameters { All = true });

            return containers.Where(c => c.Labels.Any(l => l.Value.Contains("Dockerbase")));
        }

        public async Task StopDockerContainerAsync(string containerId)
        {
            await _model.dockerClient.Containers.StopContainerAsync(containerId, new ContainerStopParameters());
        }

        public async Task DeleteDockerContainerAsync(string containerId)
        {
            await _model.dockerClient.Containers.StopContainerAsync(containerId, new ContainerStopParameters());
            await _model.dockerClient.Containers.RemoveContainerAsync(containerId, new ContainerRemoveParameters());
        }


    }
}
