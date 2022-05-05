using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Brand : BaseEntity
    {
        public string Title { get; set; }
        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }
    }
}