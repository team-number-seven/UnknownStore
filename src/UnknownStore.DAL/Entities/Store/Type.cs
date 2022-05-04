using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownStore.DAL.Entities.Store
{
    public class Type:BaseEntity
    {
        public string Title { get; set; }

        public AgeType AgeType { get; set; }
        public Guid AgeTypeId { get; set; }

        public virtual IEnumerable<SubType> SubTypes { get; set; }
        public Guid SubTypeId { get; set; }
    }
}
