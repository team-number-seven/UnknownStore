using System;
using System.Collections.Generic;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateOrderDto
    {
        public decimal TotalPrice { get; set; }
        public decimal DeliveryCost { get; set; }
        public decimal Discount { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string OrderDescription { get; set; }
        public string PaymentMode { get; set; }
        public string DeliveryMode { get; set; }
        public string AddressLine { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid ModelId { get; set; }
        public Guid? UserId { get; set; }
        public IEnumerable<CreateBuyModelDto> BuyModels { get; set; }
    }
}