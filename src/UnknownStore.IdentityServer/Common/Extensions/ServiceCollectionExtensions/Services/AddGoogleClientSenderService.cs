using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Services.GoogleClientSenderClientSender;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddGoogleClientSenderService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGoogleClientSenderService), typeof(GoogleClientSenderService));
            return services;
        }
    }
}