using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class Image : BaseEntity
    {
        public string Path { get; set; }
        public string Format { get; set; }
        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }
    }
}