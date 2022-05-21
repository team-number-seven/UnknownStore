using System;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateSubCategoryDto
    {
        public string Title { get; set; }
        public Guid CategoryId { get; set; }
        public CreateSizeDto Size { get; set; }
    }
}