using System;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.DAL.Entities.Store
{
    public class Comment:BaseEntity
    {
        public int Review { get; set; }
        public string Value { get; set; }
        public string CreateDate { get; set; }

        public Model Model { get; set; }
        public Guid ModelId { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
    }
}
