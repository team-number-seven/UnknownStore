using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.BusinessLogic.Behaviours;

namespace UnknownStore.BusinessLogic.Extensions.ServiceCollection.Services
{
    public static class ValidatorBehaviorExtension
    {
        public static IServiceCollection AddValidatorBehavior(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}