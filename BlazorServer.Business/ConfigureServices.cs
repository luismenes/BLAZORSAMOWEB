using BlazorServer.Business.BLL;
using BlazorServer.Business.BLL.BaseBLL;
using BlazorServer.Business.Interfaces;
using BlazorServer.Business.Interfaces.BaseBLL;
using BlazorServer.DataAccess;
using BlazorServer.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServer.Business
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseBLL<,,,>), typeof(BaseBLL<,,,>));
            services.AddScoped<IDBExampleBLLQuery, ExampleBLL>();
            //services.AddDataServices(configuration);
            return services;
        }
    }
}
