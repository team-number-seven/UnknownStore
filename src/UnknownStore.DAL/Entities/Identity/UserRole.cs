using System;
using Microsoft.AspNetCore.Identity;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.DAL.Entities.Identity
{
    public class UserRole : IdentityUserRole<Guid>, IBaseEntity
    {
        public Guid Id { get; set; }
    }
}