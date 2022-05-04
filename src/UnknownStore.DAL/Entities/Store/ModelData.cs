using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class ModelData:BaseEntity
    {
        public string Title { get; set; }
        public string Value { get; set; }

        public Model Model { get; set; }
        public Guid ModelId { get; set; }
    }
}
