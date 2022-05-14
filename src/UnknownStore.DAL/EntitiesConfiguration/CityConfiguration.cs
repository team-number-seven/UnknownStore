using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .ToTable("Cities");
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Title)
                .HasMaxLength(150);
            builder
                .HasMany(c => c.Addresses)
                .WithOne(a => a.City)
                .HasForeignKey(a => a.CityId);
            builder
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);
        }
    }
}