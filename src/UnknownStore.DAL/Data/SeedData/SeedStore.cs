using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
            var pathToColors = srcPath + configuration["SeedDataLocalPath:Colors"];
            var pathToGenders = srcPath + configuration["SeedDataLocalPath:Genders"];
            var pathToAgeTypes = srcPath + configuration["SeedDataLocalPath:AgeTypes"];
            var pathToSeasons = srcPath+configuration["SeedDataLocalPath:Seasons"];
            var pathToCategories = srcPath+configuration["SeedDataLocalPath:Categories"];

            await SeedCountriesAsync(context, pathToCountries, logger);
            await SeedColorsAsync(context, pathToColors, logger);
            await SeedGendersAsync(context, pathToGenders, logger);
            await SeedAgeTypesAsync(context, pathToAgeTypes, logger);
            await SeedBrandsAsync(context, pathToBrands, logger);
            await SeedSeasonsAsync(context, pathToSeasons, logger);
            await SeedCategoriesAsync(context, pathToCategories, logger);

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
            if (context.Countries.Any() is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var countries = jArray.ToObject<Country[]>();
                await context.Countries.AddRangeAsync(countries);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("Countries is already initialized");
        }
        public static async Task SeedColorsAsync(IStoreDbContext context, string pathToJson, ILogger<IHost> logger)
        {
            if (context.Colors.Any() is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var colors = jArray.ToObject<Color[]>();
                await context.Colors.AddRangeAsync(colors);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("Colors is already initialized");
        }
        public static async Task SeedGendersAsync(IStoreDbContext context, string pathToJson, ILogger<IHost> logger)
        {
            if (context.Genders.Any() is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var genders = jArray.ToObject<Gender[]>();
                await context.Genders.AddRangeAsync(genders);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("Genders is already initialized");
        }
        public static async Task SeedAgeTypesAsync(IStoreDbContext context, string pathToJson, ILogger<IHost> logger)
        {
            if (context.AgeTypes.Any() is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var ageTypes = jArray.ToObject<AgeType[]>();
                await context.AgeTypes.AddRangeAsync(ageTypes);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("AgeTypes is already initialized");
        }
        public static async Task SeedSeasonsAsync(IStoreDbContext context, string pathToJson, ILogger<IHost> logger)
        {
            if (context.Seasons.Any() is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var seasons = jArray.ToObject<Season[]>();
                await context.Seasons.AddRangeAsync(seasons);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("Seasons is already initialized");
        }

        public static async Task SeedCategoriesAsync(IStoreDbContext context, string pathToJson, ILogger<IHost> logger)
        {
            if (context.Categories.Any() is false)
            {
                using var sr = new StreamReader(pathToJson);
                var jReader = new JsonTextReader(sr);
                var jArray = await JArray.LoadAsync(jReader);
                var categories = jArray.ToObject<Category[]>();
                foreach (var category in categories)
                {
                    var ageType = await context.AgeTypes.FirstAsync(at => at.Title == category.AgeType.Title);
                    category.AgeType = ageType;
                    foreach (var subCategory in category.SubCategories)
                    {
                        var gender = await context.Genders.FirstAsync(g => g.Title == subCategory.Size.Gender.Title);
                        subCategory.Size.Gender = gender;
                    }
                }
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
                return;
            }
            logger.LogWarning("Categories is already initialized");
        }
    }
}
