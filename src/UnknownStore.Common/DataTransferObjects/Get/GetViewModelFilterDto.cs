using System;
using System.Collections.Generic;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetViewModelFilterDto
    {
        public string Title { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? IsAvailable { get; set; }
        public IEnumerable<Guid> SubCategoriesId { get; set; }
        public IEnumerable<Guid> BrandsId { get; set; }
        public IEnumerable<Guid> AgeTypesId { get; set; }
        public IEnumerable<Guid> GendersId { get; set; }
        public IEnumerable<Guid> ColorsId { get; set; }
        public IEnumerable<Guid> CategoriesId { get; set; }
        public IEnumerable<Guid> SeasonsId { get; set; }
        public string CategoryTitle { get; set; }
        public string BrandTitle { get; set; }
        public string GenderTitle { get; set; }
        public string ColorTitle { get; set; }
        public string SubCategoryTitle { get; set; }
        public string SeasonTitle { get; set; }
        public string AgeTypeTitle { get; set; }
    }
}