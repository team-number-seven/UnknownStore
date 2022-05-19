using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Model : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual Brand Brand { get; set; }
        public Guid BrandId { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public Guid SubCategoryId { get; set; }

        public virtual Color Color { get; set; }
        public Guid ColorId { get; set; }

        public virtual Factory Factory { get; set; }
        public Guid FactoryId { get; set; }

        public virtual Season Season { get; set; }
        public Guid SeasonId { get; set; }

        public virtual MainImage MainImage { get; set; }

        public virtual IEnumerable<Image> Images { get; set; }

        public virtual IEnumerable<AmountOfSize> AmountOfSizes { get; set; }

        public virtual IEnumerable<ModelData> ModelData { get; set; }
    }
}