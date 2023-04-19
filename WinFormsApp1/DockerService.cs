using Docker.DotNet;
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
        public async Task CreateDockerContainer(string port, string password, string name)
        {
            string _port = port + "/tcp";
            var containerCreateParameters = new CreateContainerParameters
            {
                Image = "mysql",
                Name = name,
                Env = new List<string> { "MYSQL_ROOT_PASSWORD=" + password },
                HostConfig = new HostConfig
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { _port, new List<PortBinding> { new PortBinding { HostPort = port } } }
                    }
                }
            };
            await DockerClient.Containers.CreateContainerAsync(containerCreateParameters);
        }
    }
}
