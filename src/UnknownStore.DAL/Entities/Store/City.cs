using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class City : BaseEntity
    {
        public string Title { get; set; }
        public virtual Country Country { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
        public Guid CountryId { get; set; }
    }
}