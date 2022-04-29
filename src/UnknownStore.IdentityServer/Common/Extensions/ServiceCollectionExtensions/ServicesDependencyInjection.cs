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
            services.AddIdentityServer4(configuration);
            services.AddCustomProfileService();
            services.AddStoreContext(configuration);
            services.AddEmailService();
            services.AddGoogleClientSenderService();
            services.AddModelsBuilder();
            services.AddControllersWithViews();
            return services;
        }
    }
}