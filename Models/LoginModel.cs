using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace DockerbaseWPF.Models
{
    public class LoginModel
    {
        private string connectionString;

        public LoginModel()
        {
            connectionString = "server=127.0.0.1;user=root;database=userDB;port=3306;password=rootpassword;";
        }

        internal ViewModels.LoginViewModel LoginViewModel
        {
            get => default;
            set
            {
            }
        }

        public (string, string) GetUserInfo(string username)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open)
                {
                    string query = "SELECT * FROM users WHERE username = @username";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string _username = reader.GetString("username");
                            string _password = reader.GetString("password");
                            return (_username, _password);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (null, null);
        }
    }
}
