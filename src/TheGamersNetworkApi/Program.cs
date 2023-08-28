namespace TheGamersNetworkApi
{
    public static class Program
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
                Console.Write(ex);
                return 1;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            webBuilder.ConfigureKestrel((options) =>
            options.Limits.MaxRequestBodySize = 53000
            )
            .UseStartup<Startup>());
        }
    }
}
