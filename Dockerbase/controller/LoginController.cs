﻿using DockerBase.model;
using DockerBase.view;

namespace DockerBase.controller
{
    internal class LoginController
    {
        private LoginView view;
        private UserModel model;
        public LoginController(LoginView view, UserModel model)
        {
            this.view = view;
            this.model = model;

            // Set up event handlers for the login button
        }
        public void LoginBtn_Event(object sender, EventArgs e)
        {
            string username = view.Username;
            string password = view.Password;

            bool isValid = model.ValidateUser(username, password);

            if (isValid)
            {
                MessageBox.Show("Login successful!");
                new MenuView().Show();
                view.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
                username = null;
                password = null;
            }
        }
    }
}
