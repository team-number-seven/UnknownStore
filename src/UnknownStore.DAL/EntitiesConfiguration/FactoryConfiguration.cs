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
                .HasMany(f => f.Models)
                .WithOne(m => m.Factory)
                .HasForeignKey(f => f.FactoryId);
            builder
                .HasOne(f => f.Address)
                .WithOne(a => a.Factory)
                .HasForeignKey<Factory>(f => f.AddressId);
        }
    }
}