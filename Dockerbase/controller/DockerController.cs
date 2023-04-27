using Docker.DotNet.Models;
using DockerBase.model;
using DockerBase.view;

namespace DockerBase.controller
{
    internal class DockerController
    {
        private readonly DockerModel dockerModel;

        public DockerController(DockerModel model)
        {
            dockerModel = model;
        }

        public async Task<CreateContainerResponse> CreateDockerContainerAsync(string password, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                CreateDatabaseView.Instance.ValidateParamenters(name);
            }

            // Retrieve a list of currently bound host ports
            var usedPorts = await DockerModel.Instance.GetUsedHostPortsAsync();

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
            var container = await DockerModel.Instance.dockerClient.Containers.CreateContainerAsync(containerCreateParameters);

            // Start the container
            await dockerModel.dockerClient.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());
            return container;
        }
        // Add additional methods as needed
    }
}
