using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Color : BaseEntity
    {
        public string Title { get; set; }
        public string HexCode { get; set; }

        public virtual IEnumerable<Model> Models { get; set; }
    }
}