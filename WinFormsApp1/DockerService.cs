using Docker.DotNet;
using Docker.DotNet.Models;

namespace WinFormsApp1
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

        public async Task StartCompose()
        {
            var imageCreateParameters = new ImagesCreateParameters
            {
                FromImage = "mariadb",
                Tag = "latest"
            };

            await DockerClient.Images.CreateImageAsync(imageCreateParameters, null, new Progress<JSONMessage>(), CancellationToken.None);

            Console.WriteLine("MariaDB image created successfully!");
        }
    }
}
