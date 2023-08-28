using Npgsql;

namespace Database.Config
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string _connectionString;

        public ConnectionStringProvider()
        {
            var connectionString = new NpgsqlConnectionStringBuilder() {
                Host = Environment.GetEnvironmentVariable("POSTGRES_HOST"),
                Port = 5432,
                Username = Environment.GetEnvironmentVariable("POSTGRES_USER"),
                Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"),
                Database = Environment.GetEnvironmentVariable("POSTGRES_DB")
             };
            _connectionString = connectionString.ConnectionString;
        }

        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            private set { }
        }
    }
}