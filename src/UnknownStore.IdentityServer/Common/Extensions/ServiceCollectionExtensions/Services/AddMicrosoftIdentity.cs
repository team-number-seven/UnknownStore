using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using UnknownStore.DAL;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.IdentityServer.Common.Extensions.ServiceCollectionExtensions.Services
{
    public static partial class IdentityDependencyInjection
    {
        public static IServiceCollection AddMicrosoftIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(opt =>
                {
                    opt.Password.RequireLowercase = false;
                    opt.Password.RequireDigit = true;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequiredUniqueChars = 1;

                    opt.SignIn.RequireConfirmedAccount = false;
                    opt.SignIn.RequireConfirmedEmail = true;
                    opt.SignIn.RequireConfirmedPhoneNumber = false;

                    opt.Lockout.MaxFailedAccessAttempts = 9;
                    opt.Lockout.AllowedForNewUsers = true;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<StoreDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}