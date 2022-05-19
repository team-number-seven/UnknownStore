using System;

namespace UnknownStore.Common.DataTransferObjects.Update
{
    public class UpdateOrderStatusDto
    {
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}