using MySql.Data.MySqlClient;

namespace DockerBase
{
    internal class UserDB
    {

        private MySqlConnection? conn;
        private readonly MySqlCommand? cmd;

        public void ConnectToDB(string userName, string password, string port)
        {
            string _userName = userName;
            string _password = password;
            string _port = port;
            string url = "Server=127.0.0.1;Port=" + _port + ";Database=userDB;Uid=" + userName + ";Pwd=" + password + ";";

            try
            {
                conn = new MySqlConnection(url);
                conn.Open();
                Console.WriteLine("Connected to MySQL database.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error connecting to MySQL database: " + e.Message);
            }
        }

        public void QueryDB(string username, string password, Action<bool> callback)
        {
            string sql = "SELECT * FROM users WHERE username = @username AND password = @password;";
            int result = 0;

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }

            bool isValid = (result > 0);
            callback(isValid);
            conn.Close();
        }

        public void ValidateUser(string username, string password, Action<bool> callback)
        {
            QueryDB(username, password, (isValid) =>
            {
                callback(isValid);
            });
        }
    }
}
