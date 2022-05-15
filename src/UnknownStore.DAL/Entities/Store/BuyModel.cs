using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class BuyModel:BaseEntity
    {
        public double? Size { get; set; }
        public int Amount { get; set; }

        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }

        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
