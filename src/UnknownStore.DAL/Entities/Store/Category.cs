using System;
using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }

        public virtual AgeType AgeType { get; set; }
        public Guid AgeTypeId { get; set; }
        public virtual Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}