using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Options
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddConfigurationAppCookie(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
                config.Cookie.Name = "IdentityServer.Cookie";
            });
            return services;
        }
    }
}
