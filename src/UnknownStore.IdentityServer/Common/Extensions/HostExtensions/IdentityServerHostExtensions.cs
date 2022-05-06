using System;
using System.IO;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnknownStore.DAL.Data.SeedData;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.IdentityServer.Common.Extensions.HostExtensions
{
    public static class IdentityServerHostExtensions
    {
        public static async Task IdentityServerHostConfigure(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var currentDir = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));
            var pathRolesJson = currentDir + configuration["SeedIdentity:Roles"];

            configuration["CurrentDirectory"] = currentDir;

            var logger = scope.ServiceProvider.GetRequiredService<ILogger<IHost>>();
            try
            {
                await SeedIdentity.SeedConfigurationAsync(configurationDbContext, logger, configuration);
                await SeedIdentity.SeedRolesAsync(roleManager, pathRolesJson, logger);
                await SeedIdentity.SeedUsersAsync(userManager, configuration, logger);
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