namespace TheGamersNetworkApi
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            try
            {
                app.Run();
                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return CreateHostBuilder.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
                webBuilder.ConfigureKestrel((context, options) =>
                {
                    options.Limits.MaxRequestBodySize = 53000;
                }))
            .UseStartup<Startup>();
        }
    }
}
