using System.Data;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;

namespace TheDependencyProblem.Data;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateDbConnectionAsync();
}

public class MySqlDbConnectionFactory : IDbConnectionFactory
{
    public async Task<IDbConnection> CreateDbConnectionAsync()
    {
        return new MySqlConnection();
    }
}

public class SqliteDbConnectionFactory : IDbConnectionFactory
{
    private readonly DbConnectionOptions _connectionOptions;

    public SqliteDbConnectionFactory()
    {
        _connectionOptions = new DbConnectionOptions
        {
            ConnectionString = "Data Source=./database.db"
        };
    }

    public async Task<IDbConnection> CreateDbConnectionAsync()
    {
        var connection = new SqliteConnection(_connectionOptions.ConnectionString);
        await connection.OpenAsync();
        return connection;
    }
}
