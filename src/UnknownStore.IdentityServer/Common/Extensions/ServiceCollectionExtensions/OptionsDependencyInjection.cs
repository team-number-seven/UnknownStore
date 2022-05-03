using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Options;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions
{
    public static class OptionsDependencyInjection
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddConfirmAndDeclineUrlOptions(configuration);
            services.AddEmailSenderOptions(configuration);
            services.AddGoogleOptions(configuration);
            services.AddConfigurationAppCookie(configuration);
            return services;
        }
    }
}