using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class SubCategory : BaseEntity
    {
        public string Title { get; set; }

        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public virtual Size Size { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }
    }
}