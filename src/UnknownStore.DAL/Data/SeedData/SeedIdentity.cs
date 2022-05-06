using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.DAL.Data.SeedData
{
    public static class SeedIdentity
    {
        public static async Task SeedConfigurationAsync(ConfigurationDbContext context, ILogger<IHost> logger,
            IConfiguration configuration)
        {
            if (context.Clients.Any() is false)
            {
                var clients = configuration.GetSection("IdentityServer:Clients").Get<IEnumerable<Client>>();
                foreach (var s in clients) await context.Clients.AddAsync(s.ToEntity());
            }
            else
            {
                logger.LogWarning("Clients is already initialized ");
            }

            if (context.IdentityResources.Any() is false)
            {
                var identityResources = new[]
                {
                    new IdentityResources.Profile().ToEntity(),
                    new IdentityResources.OpenId().ToEntity(),
                    new IdentityResources.Email().ToEntity()
                };
                await context.IdentityResources.AddRangeAsync(identityResources);
            }
            else
            {
                logger.LogWarning("IdentityResources is already initialized ");
            }

            if (context.ApiScopes.Any() is false)
            {
                var apiScopes = configuration.GetSection("IdentityServer:ApiScopes")
                    .Get<IEnumerable<ApiScope>>();
                foreach (var apiScope in apiScopes) await context.ApiScopes.AddAsync(apiScope.ToEntity());
            }
            else
            {
                logger.LogWarning("ApiScopes is already initialized ");
            }

            if (context.ApiResources.Any() is false)
            {
                var apiResources = configuration.GetSection("IdentityServer:ApiResources")
                    .Get<IEnumerable<ApiResource>>();
                foreach (var apiResource in apiResources) await context.ApiResources.AddAsync(apiResource.ToEntity());
            }
            else
            {
                logger.LogWarning("ApiResources is already initialized");
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedRolesAsync(RoleManager<Role> roleManager, string pathJson, ILogger<IHost> logger)
        {
            if (roleManager.Roles.Any() is false)
            {
                using var sr = new StreamReader(pathJson);
                var jReader = new JsonTextReader(sr);
                var t = await JArray.LoadAsync(jReader);
                var roles = t.ToObject<IEnumerable<Role>>();
                foreach (var role in roles) await roleManager.CreateAsync(role);
            }
            else
            {
                logger.LogWarning("Roles is already initialized");
            }
        }

        public static async Task SeedUsersAsync(UserManager<User> userManager, IConfiguration configuration,
            ILogger<IHost> logger)
        {
            if (userManager.Users.Any() is false)
            {
                var users = configuration.GetSection("Users").Get<IEnumerable<User>>();
                foreach (var user in users)
                {
                    user.Id = Guid.NewGuid();
                    user.UserName = user.Id + "|" + user.UserName;
                    user.CreateDateTime = DateTime.Now.ToString("s");
                    var result = await userManager.CreateAsync(user, user.PasswordHash);
                    await userManager.AddToRoleAsync(user, "Owner");
                    await userManager.AddClaimsAsync(user, new List<Claim> { new(ClaimTypes.Role, "Owner") });
                }
            }
            else
            {
                logger.LogWarning("User is already initialized");
            }
        }
    }
}