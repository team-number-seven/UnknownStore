using IdentityServer4.Services;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Services.GoogleClientSenderClientSender;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddCustomProfileService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IProfileService), typeof(ProfileService));
            return services;
        }
    }
}