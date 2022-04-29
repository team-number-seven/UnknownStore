using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Services.BuilderModels;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddModelsBuilder(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ModelsBuilder));
            return services;
        }
    }
}