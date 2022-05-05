using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class AmountOfSize : BaseEntity
    {
        public double Value { get; set; }
        public int Amount { get; set; }

        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }
    }
}