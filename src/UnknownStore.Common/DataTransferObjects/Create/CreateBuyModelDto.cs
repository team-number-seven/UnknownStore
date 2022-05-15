using System;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateBuyModelDto
    {
        public double? Size { get; set; }
        public Guid ModelId { get; set; }
        public int Amount { get; set; }

    }
}
