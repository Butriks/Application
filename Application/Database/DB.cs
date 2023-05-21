using MySql.Data.MySqlClient;

namespace Application.Database;

public class DB
{
    private readonly string connectionString;
    private MySqlConnection connection;

    public DB(string server, int port, string username, string password, string database)
    {
        connectionString = $"server={server};port={port};username={username};password={password};database={database}";
    }

    public MySqlConnection OpenConnection()
    {
        if (connection == null)
        {
            connection = new MySqlConnection(connectionString);
        }

        if (connection.State != System.Data.ConnectionState.Open)
        {
            connection.Open();
        }

        return connection;
    }

    public void CloseConnection()
    {
        if (connection != null && connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
        }
    }

    public MySqlConnection GetConnection()
    {
        return connection;
    }

    public void ExecuteNonQuery(string query)
    {
        try
        {
            CloseConnection();
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            command.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Ошибка выполнения запроса: " + ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    public MySqlDataReader ExecuteReader(string query)
    {
        try
        {
            CloseConnection();
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteReader();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Ошибка выполнения запроса: " + ex.Message);
            return null;
        }
    }

    public object ExecuteScalar(string query)
    {
        try
        {
            CloseConnection();
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, connection);
            return command.ExecuteScalar();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Ошибка выполнения запроса: " + ex.Message);
            return null;
        }
        finally
        {
            CloseConnection();
        }

    }
    static public void CloseDataReader(MySqlDataReader reader)
    {
        if (reader != null && !reader.IsClosed)
        {
            reader.Close();
        }
    }

}

