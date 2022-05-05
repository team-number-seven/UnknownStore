using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownStore.DAL.Entities.Store
{
    public class SubCategory:BaseEntity
    {
        public string Title { get; set; }

        public virtual Category Category { get; set; }
        public Guid CategoryId { get; set; }

        public virtual Size Size { get; set; }
        public Guid SizeId { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }
    }
}
