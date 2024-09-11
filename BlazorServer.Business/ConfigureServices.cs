using BlazorServer.Business.BLL;
using BlazorServer.Business.BLL.BaseBLL;
using BlazorServer.Business.BLL.Contratacion;
using BlazorServer.Business.BLL.EncryDecrypt;
using BlazorServer.Business.BLL.TablaDatos;
using BlazorServer.Business.Interfaces;
using BlazorServer.Business.Interfaces.BaseBLL;
using BlazorServer.Business.Interfaces.Contratacion;
using BlazorServer.Business.Interfaces.EncryDecrypt;
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
            //services.AddScoped(typeof(IBaseBLL<,,,>), typeof(BaseBLL<,,,>));
            //services.AddScoped<IDBExampleBLLQuery, ExampleBLL>();
            services.AddScoped(typeof(IEncryDecrypt), typeof(EncryDecrypt));
            services.AddScoped(typeof(IUser), typeof(UserRedis));
            services.AddScoped(typeof(IEntidadSamo), typeof(EntidadSamo));
            services.AddScoped(typeof(IConveniosSAM), typeof(ConveniosSAM));
            services.AddScoped<TablaDatoService>();
            services.AddScoped<GlobalStateService>();

            services.AddDataServices(configuration);
            return services;
        }
    }
}
