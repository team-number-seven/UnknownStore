using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class BuyModel:BaseEntity
    {
        public string Size { get; set; }

        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }

        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
