using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions
{
    public static class ServicesDependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMicrosoftIdentity();
            services.AddStoreContext(configuration);
            services.AddEmailService();
            services.AddModelsBuilder();
            services.AddIdentityServer4(configuration);
            services.AddGoogleService(configuration);
            services.AddCustomProfileService();


            services.AddControllersWithViews();
            return services;
        }
    }
}