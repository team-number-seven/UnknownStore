using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace UnknownStore.Common.DataTransferObjects
{
    public class CreateModelDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Guid BrandId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SeasonId { get; set; }
        public Guid FactoryId { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
        public IDictionary<string,string> AmountOfSize { get; set; }
        public IDictionary<string,string> ModelData { get; set; }
    }
}
