using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class AgeType : BaseEntity
    {
        public string Title { get; set; }

        public virtual IEnumerable<Category> Types { get; set; }
    }
}