using Microsoft.AspNetCore.Mvc;
using UnknownStore.Common.Mappings;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.Common.DataTransferObjects.Get
{
    public class GetViewModelDto:IMapWith<Model>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public GetBrandDto Brand { get; set; }
        public GetSubCategoryDto SubCategory { get; set; }

        public FileContentResult MainImage { get; set; }
    }
}
