using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Services.GoogleClientSenderClientSender;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddGoogleService(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(typeof(IGoogleService), typeof(GoogleService));
            services.AddAuthentication()
                .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = configuration["GoogleClientSenderOptions:ClientId"];
                    options.ClientSecret = configuration["GoogleClientSenderOptions:ClientSecret"];
                });
            return services;
        }
    }
}