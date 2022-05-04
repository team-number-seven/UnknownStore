using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownStore.DAL.Entities.Store
{
    public class AgeType:BaseEntity
    {
        public string Title { get; set; }
        
        public virtual IEnumerable<Type> Types { get; set; }
    }
}
