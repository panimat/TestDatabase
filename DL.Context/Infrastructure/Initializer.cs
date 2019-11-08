using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DL.Context.Interfaces;
using DL.Context.Context;
using DL.Context.Repositories;

namespace DL.Context.Infrastructure
{
    public static class Initialize
    {
        private static IServiceCollection _services;
        private static IConfiguration _configuration;
        private static ILogger _logger;

        public static void AddDataServices(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
            _services = services;
            _configuration = configuration;
            _logger = logger;
            MigrateDatabase();
            RegisterServices();
        }

        private static void MigrateDatabase()
        {
            var context = (AppDbContext)_services.BuildServiceProvider().GetService(typeof(AppDbContext));
            //context.Database.Migrate();
        }

        private static void RegisterServices()
        {
            _logger.LogInformation("Register Data service");

            _services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=testDb");
            });

            _services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
