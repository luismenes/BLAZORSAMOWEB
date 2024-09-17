using BlazorServer.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorServer.DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SamoContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DBConectionString")));

            return services;
        }
    }
}
