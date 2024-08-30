using AutoMapper;
using BlazorServer.Business.AutoMapper;

namespace BlazorServer.Presentation.Modules.AutoMapper
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {

            var MappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingsProfiles());
            });

            IMapper mapper = MappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
