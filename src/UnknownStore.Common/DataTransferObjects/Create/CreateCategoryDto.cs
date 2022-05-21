using System;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateCategoryDto
    {
        public string Title { get; set; }
        public Guid AgeTypeId { get; set; }
        public Guid GenderId { get; set; }
    }
}