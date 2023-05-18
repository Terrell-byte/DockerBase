using System;

namespace DockerbaseWPF.ViewModels
{
    public class Messenger
    {
        private static Messenger _instance;
        public static Messenger Instance => _instance ?? (_instance = new Messenger());
        public class StringEventArgs : EventArgs
        {
            public string Value { get; set; }
            public string Key { get; set; }
        }
        public event EventHandler<StringEventArgs> StringValueChanged;
        public void Send(string key, string value)
        {
            StringValueChanged?.Invoke(this, new StringEventArgs { Key = key, Value = value });
        }
    }
}
