using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.DAL.Interfaces
{
    public interface IIdentityDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserClaim> UserClaims { get; set; }
        DbSet<UserRole> UserRoles { get; set; }
        DbSet<UserLogin> UserLogins { get; set; }
        DbSet<RoleClaim> RoleClaims { get; set; }
        DbSet<UserToken> UserTokens { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}