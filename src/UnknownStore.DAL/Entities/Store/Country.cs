using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Country : BaseEntity
    {
        public string Title { get; set; }
        public virtual IEnumerable<Factory> Factories { get; set; }
    }
}