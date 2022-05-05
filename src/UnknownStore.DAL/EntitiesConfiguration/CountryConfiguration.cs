using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .ToTable("Countries");
            builder
                .HasKey(c => c.Id);
            builder
                .HasIndex(c => c.Title)
                .IsUnique();
            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .HasMany(c => c.Factories)
                .WithOne(f => f.Country)
                .HasForeignKey(f => f.CountryId);
        }
    }
}