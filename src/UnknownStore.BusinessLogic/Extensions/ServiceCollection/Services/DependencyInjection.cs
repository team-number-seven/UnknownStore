using Microsoft.Extensions.DependencyInjection;
using UnknownStore.Common.Mappings;

namespace UnknownStore.BusinessLogic.Extensions.ServiceCollection.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(typeof(IMapWith<>).Assembly));
            });
            return services;
        }
    }
}