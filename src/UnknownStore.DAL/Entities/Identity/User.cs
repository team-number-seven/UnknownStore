using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string CreateDateTime { get; set; } = DateTime.Now.ToString("s");

        public virtual Comment Comment { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual IEnumerable<BuyModel> BagItems { get; set; }
        public virtual IEnumerable<Model> FavoriteItems { get; set; }
    }
}