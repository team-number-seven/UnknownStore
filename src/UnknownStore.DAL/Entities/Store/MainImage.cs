using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnknownStore.DAL.Entities.Store
{
    public class MainImage:BaseImage
    {
        public virtual Model Model { get; set; }
        public Guid ModelId { get; set; }
    }
}
