using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using UnknownStore.BusinessLogic.Extensions.ServiceCollection;
using UnknownStore.Common.Constants;
using UnknownStore.DAL;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();
            services.AddDbContext<StoreDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies().UseNpgsql(Configuration.GetConnectionString("StoreDb"));
            }).AddScoped(typeof(IStoreDbContext), typeof(StoreDbContext));

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


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
                {
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromSeconds(5),
                        ValidateAudience = false
                    };

                    config.Authority = "https://localhost:1001";
                });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseCors(opt =>
            {
                opt.AllowAnyHeader();
                opt.AllowAnyMethod();
                opt.AllowAnyOrigin();
            });

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }
    }
}