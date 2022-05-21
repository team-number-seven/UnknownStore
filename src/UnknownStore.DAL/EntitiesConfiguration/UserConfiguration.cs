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
                .HasMany(u => u.FavoriteModels)
                .WithMany(m => m.UsersFavoriteModels)
                .UsingEntity(e => e.ToTable("FavoriteModels"));

            builder
                .HasMany(u => u.BagModels)
                .WithOne(b => b.UserBagModel)
                .HasForeignKey(b => b.UserBagModelId);
        }
    }
}