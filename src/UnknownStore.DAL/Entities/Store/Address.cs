using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Address : BaseEntity
    {
        public string AddressLine { get; set; }

        public virtual City City { get; set; }
        public Guid CityId { get; set; }

        public virtual Factory Factory { get; set; }
        public virtual DeliveryPoint DeliveryPoint { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}