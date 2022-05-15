using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Season : BaseEntity
    {
        public string Title { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }
    }
}