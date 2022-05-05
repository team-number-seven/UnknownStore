using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class FactoryConfiguration : IEntityTypeConfiguration<Factory>
    {
        public void Configure(EntityTypeBuilder<Factory> builder)
        {
            builder
                .ToTable("Factories");
            builder
                .HasKey(f => f.Id);
            builder
                .Property(f => f.Title)
                .IsRequired()
                .HasMaxLength(150);
            builder
                .Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasOne(f => f.Country)
                .WithMany(c => c.Factories)
                .HasForeignKey(f => f.CountryId);

            builder
                .HasMany(f => f.Models)
                .WithOne(m => m.Factory)
                .HasForeignKey(f => f.FactoryId);
        }
    }
}