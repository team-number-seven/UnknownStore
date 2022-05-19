﻿using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class BuyModel:BaseEntity
    {
        public int Amount { get; set; }

        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }

        public virtual AmountOfSize AmountOfSize { get; set; }
        public Guid AmountOfSizeId { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
