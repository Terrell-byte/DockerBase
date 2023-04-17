using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerBase
{
    internal class UserDB
    {

        private MySqlConnection? conn;
        private readonly MySqlCommand? cmd;

        public bool ValidateUser(string username, string password)
        {
            //we need to connect to the mariadb docker container
            //we need to query the database for the username and password
            //we need to return true if the username and password match
            //we need to return false if the username and password do not match
            return false;
        }
        public void ConnectToDB(string userName, string password, string port)
        {
            string _userName = userName;
            string _password = password;
            string _port = port;
            string url = "Server=localhost;Port=" + _port + ";Database=userDB;Uid=" + userName + ";Pwd=" + password + ";";

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
    
        public void QueryDB()
        {
            //we need to query the database for the username and password
        }
        public bool CheckUser(string username, string password)
        {
            //we need to return true if the username and password match
            //we need to return false if the username and password do not match
            return false;
        }
    }
}
