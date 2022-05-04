using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Factory:BaseEntity
    {
        public string Title { get; set; }
        public string FactoryAddress { get; set; }
        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }

        public IEnumerable<Model> Models { get; set; }
    }
}