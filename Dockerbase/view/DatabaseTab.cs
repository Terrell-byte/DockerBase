﻿using DockerBase;
using DockerBase.controller;
using DockerBase.model;

namespace DockerBase.view

{
    public partial class DatabaseTab : Form
    {

        public DatabaseTab()
        {
            InitializeComponent();
        }

        private void DatabaseTab_Load(object sender, EventArgs e)
        {
            
        }

        private void Tab_Click(object sender, EventArgs e)
        {

        }

        public String DatabaseName
        {
            get { return Tab.Text; }
            set { Tab.Text = value; }
        }
    }
}