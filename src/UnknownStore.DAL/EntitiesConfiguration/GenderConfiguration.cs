using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder
                .ToTable("Genders");
            builder
                .HasKey(g => g.Id);
            builder
                .HasIndex(g => g.Title)
                .IsUnique();
            builder
                .Property(g => g.Title)
                .HasMaxLength(75)
                .IsRequired();
            builder
                .HasMany(g => g.SubCategories)
                .WithOne(s => s.Gender)
                .HasForeignKey(s => s.GenderId);
        }
    }
}