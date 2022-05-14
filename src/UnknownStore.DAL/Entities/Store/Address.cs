using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class Address : BaseEntity
    {
        public string AddressLine { get; set; }
        public virtual Country Country { get; set; }
        public Guid CountryId { get; set; }
        public virtual City City { get; set; }
        public Guid CityId { get; set; }
        public virtual Factory Factory { get; set; }
    }
}