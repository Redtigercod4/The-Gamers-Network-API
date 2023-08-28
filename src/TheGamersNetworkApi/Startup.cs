using Microsoft.AspNetCore.Cors.Infrastructure;

namespace TheGamersNetworkApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private static void ConfigureCommonServies(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddControllers();
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureCommonServies(services);
            Database.ServicesConfiguration.ConfigureDevelopmentServices(services);

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "development",
                    policyBuilder =>
                        policyBuilder.RequireAssertion(context => true)
                );
            });
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            ConfigureCommonServies(services);
            Database.ServicesConfiguration.ConfigureProductionServices(services);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy => policy.RequireClaim("user_roles", "[Administrator]"));
                options.AddPolicy("ArenaManager", policy => policy.RequireClaim("user_roles", "[ArenaManager]"));
                options.AddPolicy("Gamer", policy => policy.RequireClaim("user_roles", "[Gamer]"));
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseCors(builder =>
            builder.WithOrigins(Configuration["Cors"].Split(" "))
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
            app.UseEndpoints(endpoints =>
                endpoints.MapControllers()
            );
        }
    }
}