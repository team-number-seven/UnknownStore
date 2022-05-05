using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class ModelData:BaseEntity
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }
    }
}
