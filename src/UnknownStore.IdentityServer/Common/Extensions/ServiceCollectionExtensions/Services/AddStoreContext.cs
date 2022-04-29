using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.DAL;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddStoreContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<StoreDbContext>(options =>
                {
                    options.UseLazyLoadingProxies()
                        .ConfigureWarnings(x => x.Ignore(RelationalEventId.MultipleCollectionIncludeWarning))
                        .UseNpgsql(configuration.GetConnectionString("StoreDb"));
                })
                .AddScoped(typeof(IIdentityDbContext), typeof(StoreDbContext));
            return services;
        }
    }
}