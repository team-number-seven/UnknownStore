using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class BuyModel:BaseEntity
    {
        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }
        public string Size { get; set; }
    }
}
