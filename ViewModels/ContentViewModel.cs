using DockerbaseWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerbaseWPF.ViewModels
{
    public class ContentViewModel : ViewModelBase
    {
        //variables
        private string _focusedContainer;
        private DockerViewModel _dockerViewModel;
        private ContainerModel _container;

        //Constructor
        public ContentViewModel()
        {
            Messenger.Instance.StringValueChanged += OnStringValueChanged;
            _dockerViewModel = new DockerViewModel();
        }

        //Methods
        public void OnStringValueChanged(object sender, Messenger.StringEventArgs e)
        {
            if (e.Key == "ContainerName")
            {
                FocusedContainer = e.Value;
            }
        }
        private async Task UpdateContainerAsync()
        {
            _container = await _dockerViewModel.GetContainerByNameAsync(_focusedContainer);
        }
        //Getters and Setters
        public string FocusedContainer
        {
            get { return _focusedContainer; }
            set
            {
                _focusedContainer = value;
                OnPropertyChanged("FocusedContainer");
                _ = UpdateContainerAsync();
            }
        }
    }
}
