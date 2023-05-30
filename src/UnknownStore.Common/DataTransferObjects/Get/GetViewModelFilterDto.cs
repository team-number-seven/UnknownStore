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
        public Guid? SubCategoryId { get; set; }
        public IEnumerable<Guid> BrandsId { get; set; }
        public IEnumerable<Guid> AgeTypesId { get; set; }
        public IEnumerable<Guid> GendersId { get; set; }
        public IEnumerable<Guid> ColorsId { get; set; }
        public IEnumerable<Guid> CategoriesId { get; set; }
        public IEnumerable<Guid> SeasonsId { get; set; }
    }
}