using Npgsql;

namespace ConsoleAppBanksParseCurrencies.DB;

public class DBConnection
{
    public NpgsqlConnection Connection { private set; get; }

    public DBConnection(string host, string username, string password, string databasename)
    {
        string _connectionString =
            $"Host={host};Username={username};Password={password};Database={databasename}";

        Connection = new NpgsqlConnection(_connectionString);
        Connection.Open();
    }
}