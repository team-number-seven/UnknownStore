using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Identity;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Ignore(u => u.PhoneNumber);
            builder.Ignore(u => u.PhoneNumberConfirmed);

            builder
                .HasMany(u => u.FavoriteItems)
                .WithMany(m => m.UsersFavoriteItems)
                .UsingEntity(e => e.ToTable("FavoriteItems"));

            builder
                .HasMany(u => u.BagItems)
                .WithOne(b => b.UserBagItem)
                .HasForeignKey(b => b.UserBagItemId);
        }
    }
}