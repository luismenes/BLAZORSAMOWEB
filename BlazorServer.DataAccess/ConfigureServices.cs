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
            services.AddDbContext<FineAgendamientoDianContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("DBConectionFineDIAN")));

            return services;
        }
    }
}
