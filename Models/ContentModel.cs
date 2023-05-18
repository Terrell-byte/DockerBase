using Docker.DotNet.Models;
using DockerbaseWPF.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DockerbaseWPF.Models
{
    public class ContentModel
    {
        public DockerViewModel _dockerViewModel;

        public ContentModel()
        {
            _dockerViewModel = new DockerViewModel();
        }

        public ContentViewModel ContentViewModel
        {
            get => default;
            set
            {
            }
        }

        public async Task<ContainerModel> GetContainerByNameAsync(string containerName)
        {
            var containers = await _dockerViewModel.GetDockerbaseContainersAsync();
            var container = containers.FirstOrDefault(c => c.Names.Any(n => n.Substring(1) == containerName));

            if (container != null)
            {
                return new ContainerModel(
                    containerName,
                    container.Image,
                    container.Status,
                    container.Ports.First<Port>().PublicPort.ToString(),
                    container.Created.ToString(),
                    container.SizeRootFs.ToString(),
                    container.Labels["password"],
                    container.ID
                );
            }

            return null;
        }

        public async Task DeleteDockerContainerAsync(string containerId)
        {
            await _dockerViewModel.DeleteDockerContainerAsync(containerId);
        }
    }
}
