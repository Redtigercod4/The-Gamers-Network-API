namespace Database.Config;

public interface IConnectionStringProvider
{
    public string ConnectionString { get; }
}