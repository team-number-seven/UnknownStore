using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Factory : BaseEntity
    {
        public string Title { get; set; }

        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }
    }
}