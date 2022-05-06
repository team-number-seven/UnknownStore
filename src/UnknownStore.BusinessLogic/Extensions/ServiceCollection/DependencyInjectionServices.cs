using System.Reflection;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.BusinessLogic.Extensions.ServiceCollection.Services;

namespace UnknownStore.BusinessLogic.Extensions.ServiceCollection
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMapper();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidators();
            services.AddValidatorBehavior();
            services.AddStoreContext(configuration);
            services.AddAuthorizationPolicy();
            return services;
        }
    }
}