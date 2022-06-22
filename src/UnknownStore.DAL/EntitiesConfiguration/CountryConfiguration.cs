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
                .HasIndex(c => c.Iso2)
                .IsUnique();
            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(c => c.Iso2)
                .IsRequired();
            builder
                .HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryId);
        }
    }
}