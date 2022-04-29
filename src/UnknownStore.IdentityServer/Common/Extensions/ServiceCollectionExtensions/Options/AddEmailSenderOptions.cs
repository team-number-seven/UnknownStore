using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Common.Options;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Options
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddEmailSenderOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<EmailServiceOptions>(configuration.GetSection("EmailOptions"));
            return services;
        }
    }
}