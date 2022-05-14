using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public virtual BuyModel BuyModel { get; set; }

    }
}