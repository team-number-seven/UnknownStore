using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Size : BaseEntity
    {
        public string Standard { get; set; } = "EUR";

        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }

        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}