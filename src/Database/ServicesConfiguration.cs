using Database.Config;
using Microsoft.Extensions.DependencyInjection;

namespace Database;

public static class ServicesConfiguration
{
    static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
    }

    public static void ConfigureDevelopmentServices(IServiceCollection serviceCollection)
    {
        ConfigureServices(serviceCollection);
    }

    public static void ConfigureProductionServices(IServiceCollection serviceCollection)
    {
        ConfigureServices(serviceCollection);
    }
}