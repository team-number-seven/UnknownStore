using System;

namespace UnknownStore.DAL.Entities.Store
{
    public class MainImage : BaseImage
    {
        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }
    }
}