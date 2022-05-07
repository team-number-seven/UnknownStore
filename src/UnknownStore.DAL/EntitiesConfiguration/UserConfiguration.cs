using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Ignore(u => u.PhoneNumber);
            builder.Ignore(u => u.PhoneNumberConfirmed);
        }
    }
}
