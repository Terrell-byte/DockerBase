using MySql.Data.MySqlClient;
using System.Data;

namespace DockerBase
{
    internal class UserDB
    {
        public (string, string) GetUserInfo(string username)
        {
            string connectionString = "server=127.0.0.1;user=root;database=userDB;port=3306;password=rootpassword;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                if (connection.State == ConnectionState.Open) // added check for connection state
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
                        else
                        {
                            MessageBox.Show("Username " + username + " was not found!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR 001: an error has occured when connecting to database");
            }
            finally
            {
                connection.Close();
            }
            return (null, null);
        }


        public bool ValidateUser(string username, string password)
        {
            (string _username, string _password) = GetUserInfo(username);
            if (_username != null && _password != null && username == _username && password == _password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
