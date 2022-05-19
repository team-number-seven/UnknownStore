using System.Collections.Generic;

namespace UnknownStore.DAL.Entities.Store
{
    public class Country : BaseEntity
    {
        public string Title { get; set; }
        public string Iso2 { get; set; }

        public virtual IEnumerable<City> Cities { get; set; }


        public virtual IEnumerable<Address> Address { get; set; }
    }
}