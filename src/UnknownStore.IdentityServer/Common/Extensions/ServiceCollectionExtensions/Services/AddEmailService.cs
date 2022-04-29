using Microsoft.Extensions.DependencyInjection;
using UnknownStore.IdentityServer.Services.Email;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEmailService), typeof(EmailService));
            return services;
        }
    }
}