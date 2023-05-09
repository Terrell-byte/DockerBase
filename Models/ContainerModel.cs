﻿using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerbaseWPF.Models
{
    public class ContainerModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public string Ports { get; set; }
        public string Created { get; set; }
        public string Size { get; set; }
        public string Password { get; set; }
        
        public ContainerModel(string name, string image, string status, string ports, string created, string size, string password)
        {
            Name = name;
            Image = image;
            Status = status;
            Ports = ports;
            Created = created;
            Size = size;
            this.Password = password;
        }
    }
}
