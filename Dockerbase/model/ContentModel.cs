using MySql.Data.MySqlClient;
using System.Data;

namespace DockerBase.model
{
    internal class ContentModel
    {
        public DataTable GetContent(string password, string port)
        {
            string connectionString = "server=127.0.0.1;user=root;database=userDB;port=" + port + ";password="+ password +";";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM users";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }
    }
}
