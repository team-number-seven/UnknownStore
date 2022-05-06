using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.Common.Constants;

namespace UnknownStore.BusinessLogic.Extensions.ServiceCollection.Services
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddAuthorizationPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Roles.Owner, builder => { builder.RequireClaim(ClaimTypes.Role, Roles.Owner); });

                options.AddPolicy(Roles.Administrator, builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, Roles.Administrator) ||
                                                  x.User.HasClaim(ClaimTypes.Role, Roles.Owner));
                });

                options.AddPolicy(Roles.Manager, builder =>
                {
                    builder.RequireAssertion(x => x.User.HasClaim(ClaimTypes.Role, Roles.Manager) ||
                                                  x.User.HasClaim(ClaimTypes.Role, Roles.Administrator) ||
                                                  x.User.HasClaim(ClaimTypes.Role, Roles.Owner));
                });
                options.AddPolicy(Roles.User, builder =>
                {
                    builder.RequireAssertion(x =>
                        x.User.HasClaim(ClaimTypes.Role, Roles.User) ||
                        x.User.HasClaim(ClaimTypes.Role, Roles.Manager) ||
                        x.User.HasClaim(ClaimTypes.Role, Roles.Administrator) ||
                        x.User.HasClaim(ClaimTypes.Role, Roles.Owner));
                });
            });
            return services;
        }
    }
}
