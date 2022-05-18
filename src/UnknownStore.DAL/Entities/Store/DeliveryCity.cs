using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class DeliveryCity:BaseEntity
    {
        public virtual City City { get; set; }
        public Guid CityId { get; set; }
        public TimeSpan MaxTimeDelivered { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
    }
}