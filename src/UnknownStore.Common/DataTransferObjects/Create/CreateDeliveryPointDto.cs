using System;
using System.Collections.Generic;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateDeliveryPointDto
    {
        public string PhoneNumber { get; set; }
        public string AddressLine { get; set; }
        public Guid CityId { get; set; }
        public IEnumerable<CreateWorkDayDto> WorkDays { get; set; }
    }
}
