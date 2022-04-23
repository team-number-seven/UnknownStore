using System;
using System.IO;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnknownStore.DAL.Data.SeedData;

namespace UnknownStore.Common.Extensions
{
    public static class HostExtensions
    {
        public static async Task IdentityServerHostConfigure(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            configuration["CurrentDirectory"] = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));

            var logger = scope.ServiceProvider.GetRequiredService<ILogger<IHost>>();
            try
            {
                await SeedIdentity.Seed(configurationDbContext, logger);
            }
            catch (Exception e)
            {
                logger.LogError(
                    "[Initializing ConfigurationDbContext Identity]\n[Error Message]" +
                    $"{e.Message}\n[Error Source]{e.Source}\n[Error Inner Exception]{e.InnerException}");
            }
        }
    }
}