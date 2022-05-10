using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateModelDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid BrandId { get; set; }
        public Guid SubCategoryId { get; set; }
        public Guid ColorId { get; set; }
        public Guid SeasonId { get; set; }
        public Guid FactoryId { get; set; }
        public IFormFileCollection Files { get; set; }
        public IDictionary<double, int> AmountOfSize { get; set; }
        public IDictionary<string, string> ModelData { get; set; }
    }
}