using Database.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public class ServicesConfiguration
{
    static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
    }
}