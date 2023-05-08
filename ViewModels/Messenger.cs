using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerbaseWPF.ViewModels
{
    public class Messenger
    {
        private static Messenger _instance;

        public static Messenger Instance => _instance ?? (_instance = new Messenger());

        public event EventHandler<string> DatabaseAdded;

        public void Send(string databaseName)
        {
            DatabaseAdded?.Invoke(this, databaseName);
        }
    }

}
