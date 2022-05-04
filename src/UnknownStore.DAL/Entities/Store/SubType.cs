using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownStore.DAL.Entities.Store
{
    public class SubType:BaseEntity
    {
        public string Title { get; set; }

        public virtual Type Type { get; set; }
        public Guid TypeId { get; set; }

        public virtual Size Size { get; set; }
        public Guid SizeId { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }
        public Guid ModelId { get; set; }
    }
}
