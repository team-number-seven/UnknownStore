using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownStore.DAL.Entities.Store
{
    public class Category:BaseEntity
    {
        public string Title { get; set; }

        public virtual AgeType AgeType { get; set; }
        public Guid AgeTypeId { get; set; }

        public virtual IEnumerable<SubCategory> SubCategories { get; set; }
    }
}
