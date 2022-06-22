using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class DeliveryPoint : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public virtual Address Address { get; set; }
        public Guid AddressId { get; set; }
        public virtual IEnumerable<WorkDay> WorkDays { get; set; }
    }
}