using System;
using Microsoft.AspNetCore.Identity;

namespace UnknownStore.DAL.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        public string CreateDateTime { get; set; } = DateTime.Now.ToString("s");
    }
}