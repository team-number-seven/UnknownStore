using System;
using Microsoft.AspNetCore.Identity;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.DAL.Entities.Identity
{
    public class RoleClaim : IdentityRoleClaim<Guid>, IBaseEntity
    {
        public new Guid Id { get; set; }
    }
}