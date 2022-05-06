using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UnknownStore.BusinessLogic.Extensions.ServiceCollection.Services
{
    public static class CorsPoliceExtension
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(configuration["Cors:PolicyName"], policy =>
                {
                    policy.WithOrigins(configuration.GetSection("Cors:Origins").Get<string[]>());
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
            });
            return services;
        }
    }
}