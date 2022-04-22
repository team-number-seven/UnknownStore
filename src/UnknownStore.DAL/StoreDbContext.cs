using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UnknownStore.DAL.Entities.Identity;
using UnknownStore.DAL.Interfaces;

namespace UnknownStore.DAL
{
    public class StoreDbContext :
        IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>,
        IIdentityDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public StoreDbContext()
        {
        }
    }
}