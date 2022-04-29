using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Common.Options;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Options
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfirmAndDeclineUrlOptions(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<ConfirmAndDeclineUrlOptions>(
                configuration.GetSection("ConfirmAndDeclineUrlOptions"));
            return services;
        }
    }
}