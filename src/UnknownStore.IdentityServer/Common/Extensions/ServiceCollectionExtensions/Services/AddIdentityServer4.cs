using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.DAL;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddIdentityServer4(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("StoreDb");
            var migrationsAssembly = typeof(StoreDbContext).Assembly.GetName().Name;

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
            });
            services.AddIdentityServer()
                .AddAspNetIdentity<User>().AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseNpgsql(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly)).UseNpgsql(o =>
                        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseNpgsql(connectionString,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddDeveloperSigningCredential();

            return services;
        }
    }
}