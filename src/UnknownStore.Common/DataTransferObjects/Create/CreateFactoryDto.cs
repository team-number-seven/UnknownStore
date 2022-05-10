using System;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateFactoryDto
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public Guid CountryId { get; set; }
    }
}