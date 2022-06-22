using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .ToTable("Addresses");
            builder
                .HasKey(a => a.Id);
            builder
                .Property(c => c.AddressLine)
                .IsRequired()
                .HasMaxLength(250);
            builder
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId);
            builder
                .HasOne(a => a.Factory)
                .WithOne(f => f.Address)
                .HasForeignKey<Factory>(f => f.AddressId);
        }
    }
}