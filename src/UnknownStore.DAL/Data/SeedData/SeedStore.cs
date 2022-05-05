using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnknownStore.DAL.Entities.Store;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.DAL.Data.SeedData
{
    public static class SeedStore
    {
        public static async Task SeedDataStoreAsync(IStoreDbContext context,IConfiguration configuration,ILogger<IHost> logger)
        {
            var srcPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\"));

            var pathToBrands = srcPath + configuration["SeedDataLocalPath:Brands"];
            var pathToCountries = srcPath + configuration["SeedDataLocalPath:Countries"];
            await SeedCountriesAsync(context, pathToCountries, logger);
            await SeedBrandsAsync(context, pathToBrands, logger);
            
        }

        public static async Task SeedBrandsAsync(IStoreDbContext context, string pathToJson,ILogger<IHost> logger)
        {
            if (context.Brands.Any() is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var brands = jArray.ToObject<Brand[]>();
                foreach (var brand in brands)
                {
                    var country = await context.Countries.FirstAsync(c => c.Title == brand.Country.Title);
                    brand.Country = country;
                }
                await context.Brands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("Brands is already initialized");
        }
        public static async Task SeedCountriesAsync(IStoreDbContext context, string pathToJson, ILogger<IHost> logger)
        {
            var t = context.Countries.Any();
            if (t is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var countries = jArray.ToObject<Country[]>();
                await context.Countries.AddRangeAsync(countries);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("Brands is already initialized");
        }
    }
}
