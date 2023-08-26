using Npgsql;

namespace Database.Config
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private string _connectionString;

        public ConnectionStringProvider()
        {
            var connectionString = new NpgsqlConnectionStringBuilder();
            connectionString.Host = Environment.GetEnvironmentVariable("POSTGRES_HOST");
            connectionString.Port = 5432;
            connectionString.Username = Environment.GetEnvironmentVariable("POSTGRES_USER");
            connectionString.Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
            connectionString.Database = Environment.GetEnvironmentVariable("POSTGRES_DB");
            _connectionString = connectionString.ConnectionString;
        }

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
    }
}