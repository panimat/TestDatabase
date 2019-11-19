using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BL.Services.Interfaces;
using DL.Context.Infrastructure;
using BL.Services.Services;

namespace BL.Services.Initializer
{
    public static class Initialize
    {
        private static IServiceCollection _services;
        private static IConfiguration _configuration;
        private static ILogger _logger;

        public static void AddBuisnessServices(this IServiceCollection services, IConfiguration configuration, ILogger logger)
        {
            _services = services;
            _configuration = configuration;
            _logger = logger;
            RegisterServices();
        }


        private static void RegisterServices()
        {
            _logger.LogInformation("Register Buisness service");
            _services.AddTransient<IFindService, FindService>();
            _services.AddTransient<IJsonEntService, JsonEntService>();

            _services.AddDataServices(_configuration, _logger);
        }
    }
}
