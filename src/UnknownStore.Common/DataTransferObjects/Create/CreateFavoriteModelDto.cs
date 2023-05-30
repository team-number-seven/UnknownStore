using System;

namespace UnknownStore.Common.DataTransferObjects.Create
{
    public class CreateFavoriteModelDto
    {
        public Guid UserId { get; set; }
        public Guid ModelId { get; set; }
    }
}