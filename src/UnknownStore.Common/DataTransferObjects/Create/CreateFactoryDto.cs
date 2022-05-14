using System;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateFactoryDto
    {
        public string Title { get; set; }
        public string AddressLine { get; set; }
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
    }
}