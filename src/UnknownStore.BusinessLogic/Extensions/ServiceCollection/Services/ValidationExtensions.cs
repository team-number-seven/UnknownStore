using Microsoft.Extensions.DependencyInjection;
using UnknownStore.BusinessLogic.Services.Validation;
using UnknownStore.Common.CQRS.Validation;

namespace UnknownStore.BusinessLogic.Extensions.ServiceCollection.Services
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<IValidationService>()
                .AddClasses(classes => classes.AssignableTo<IValidationHandler>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());
            return services;
        }
    }
}