using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UnknownStore.DAL.Data.SeedData;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var context = scope.ServiceProvider.GetRequiredService<IStoreDbContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<IHost>>();
            try
            {
                await SeedStore.SeedDataStoreAsync(context, configuration, logger);
            }
            catch (Exception e)
            {
                logger.LogError(
                    "[Initializing StoreDbContext]\n[Error Message]" +
                    $"{e.Message}\n[Error Source]{e.Source}\n[Error Inner Exception]{e.InnerException}");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}