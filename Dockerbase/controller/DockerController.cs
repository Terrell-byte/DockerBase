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

        public async Task<CreateContainerResponse> CreateDockerContainerAsync(string password, string name, string type)
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

            // Copy the SQL file to the shared folder
            string sharedFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SharedFolder");
            Directory.CreateDirectory(sharedFolderPath);
            string sourceSqlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "templates", $"{type}.sql");
            string destinationSqlFilePath = Path.Combine(sharedFolderPath, $"{type}.sql");
            File.Copy(sourceSqlFilePath, destinationSqlFilePath, true);

            // Create the container with the next available port and mount the shared folder as a volume
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
                    Binds = new List<string> { $"{sharedFolderPath}:/docker-entrypoint-initdb.d" },
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
    }
}
