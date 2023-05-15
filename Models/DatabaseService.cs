using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

public class DatabaseService
{
    public async Task<int> ExecuteNonQueryAsync(string connectionString, string query)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                await connection.OpenAsync();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    return await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }

    public async Task<int> FetchScalarFromDatabaseAsync(string connectionString, string query)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
    }

    public async Task<object> FetchDataFromDatabaseAsync(string connectionString, string query)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            await connection.OpenAsync();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                try
                {
                    if (query.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        var adapter = new MySqlDataAdapter(command);
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table.DefaultView;
                    }
                    else
                    {
                        return await command.ExecuteScalarAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
    }
}
