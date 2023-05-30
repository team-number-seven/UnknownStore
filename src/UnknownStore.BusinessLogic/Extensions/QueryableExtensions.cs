using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.BusinessLogic.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<Model> FilterByGenders(this IQueryable<Model> models, IList<Guid> gendersId)
        {
            return gendersId.IsNullOrEmpty()
                ? models
                : models.Where(i => gendersId.Contains(i.SubCategory.Category.Gender.Id));
        }


        public static IQueryable<Model> FilterByBrands(this IQueryable<Model> models, IList<Guid> brandsId)
        {
            return brandsId.IsNullOrEmpty()
                ? models
                : models.Where(i => brandsId.Contains(i.BrandId));
        }


        public static IQueryable<Model> FilterByAgeTypesId(this IQueryable<Model> models, IList<Guid> ageTypesId)
        {
            return ageTypesId.IsNullOrEmpty()
                ? models
                : models.Where(i => ageTypesId.Contains(i.SubCategory.Category.AgeTypeId));
        }

        public static IQueryable<Model> FilterByColors(this IQueryable<Model> models, IList<Guid> colorsId)
        {
            return colorsId.IsNullOrEmpty()
                ? models
                : models.Where(i => colorsId.Contains(i.ColorId));
        }


        public static IQueryable<Model> FilterBySeasons(this IQueryable<Model> models, IList<Guid> seasonsId)
        {
            return seasonsId.IsNullOrEmpty()
                ? models
                : models.Where(i => seasonsId.Contains(i.SeasonId));
        }

        public static IQueryable<Model> FilterByMinPrice(this IQueryable<Model> models, decimal? price)
        {
            return price.HasValue is false
                ? models
                : models.Where(i => i.Price >= price);
        }

        public static IQueryable<Model> FilterByMaxPrice(this IQueryable<Model> models, decimal? price)
        {
            return price.HasValue is false
                ? models
                : models.Where(i => i.Price <= price);
        }

        public static IQueryable<Model> FilterByTitle(this IQueryable<Model> models, string title)
        {
            return title.IsNullOrEmpty()
                ? models
                : models.Where(i => i.Title.ToLower().Contains(title.ToLower()));
        }

        public static IQueryable<Model> FilterByIsAvailable(this IQueryable<Model> models, bool? isAvailable)
        {
            return isAvailable.HasValue && isAvailable.Value
                ? models.Where(i => i.AmountOfSizes.All(a => a.Amount > 0))
                : models;
        }

        public static IQueryable<Model> FilterBySubCategories(this IQueryable<Model> models,
            IList<Guid> subCategoriesId)
        {
            return subCategoriesId.IsNullOrEmpty()
                ? models
                : models.Where(i => subCategoriesId.Contains(i.SubCategoryId));
        }
        public static IQueryable<Model> FilterByCategories(this IQueryable<Model> models, IList<Guid> categoriesId)
        {
            return categoriesId.IsNullOrEmpty()
                ? models
                : models.Where(i => categoriesId.Contains(i.SubCategory.CategoryId));
        }

        //todo
        private static IQueryable<Model> FilterBySizes(this IQueryable<Model> models, IList<Guid> sizes)
        {
            throw new NotImplementedException();
        }
    }
}