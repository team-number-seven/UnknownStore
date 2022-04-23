using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.Extensions.Logging;
using UnknownStore.DAL.Data.InitData;

namespace UnknownStore.DAL.Data.SeedData
{
    public static class SeedIdentity
    {
        public static async Task Seed(ConfigurationDbContext context, ILogger logger)
        {
            if (context.Clients.Any() is false)
                await context.Clients.AddRangeAsync(IdentityServerConfiguration.Clients.ToArray());
            else
                logger.LogWarning("Clients is already initialized ");

            if (context.IdentityResources.Any() is false)
                await context.IdentityResources.AddRangeAsync(IdentityServerConfiguration.IdentityResources);
            else
                logger.LogWarning("IdentityResources is already initialized ");

            if (context.ApiScopes.Any() is false)
                await context.ApiScopes.AddRangeAsync(IdentityServerConfiguration.ApiScopes);
            else
                logger.LogWarning("ApiScopes is already initialized ");

            if (context.ApiResources.Any() is false)
                await context.ApiResources.AddRangeAsync(IdentityServerConfiguration.ApiResources);
            else
                logger.LogWarning("ApiResources is already initialized");

            await context.SaveChangesAsync();
        }
    }
}