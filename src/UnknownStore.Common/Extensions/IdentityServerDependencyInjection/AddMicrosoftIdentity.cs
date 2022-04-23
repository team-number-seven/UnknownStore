using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.DAL;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.Common.Extensions.IdentityServerDependencyInjection
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddMicrosoftIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<StoreDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}