using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Gender : BaseEntity
    {
        public string Title { get; set; }
        public virtual IEnumerable<Category> Categories { get; set; }
    }
}