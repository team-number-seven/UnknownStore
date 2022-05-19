using System;
using System.Collections.Generic;
using UnknownStore.DAL.Entities.Enums;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.DAL.Entities.Store
{
    public class Order : BaseEntity
    {
        public decimal TotalPrice { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal Discount { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string OrderDescription { get; set; }
        public string OrderStatusDescription { get; set; }
        public string CreteDate { get; set; }
        public string PickUpBefore { get; set; }
        public PaymentMode PaymentMode { get; set; }
        public DeliveryMode DeliveryMode { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public virtual Address DeliveryAddress { get; set; }
        public Guid DeliveryAddressId { get; set; }

        public virtual DeliveryCity DeliveryCity { get; set; }
        public Guid DeliveryCityId { get; set; }

        public virtual User User { get; set; }
        public Guid? UserId { get; set; }

        public virtual IEnumerable<BuyModel> BuyModels { get; set; }
    }
}