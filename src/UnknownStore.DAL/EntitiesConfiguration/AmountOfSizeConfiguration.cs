using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class AmountOfSizeConfiguration : IEntityTypeConfiguration<AmountOfSize>
    {
        public void Configure(EntityTypeBuilder<AmountOfSize> builder)
        {
            builder
                .ToTable("AmountOfSizes");
            builder
                .HasKey(aof => aof.Id);
            builder
                .Property(aof => aof.Amount)
                .IsRequired();
            builder
                .Property(aof => aof.Value)
                .IsRequired();
            builder
                .HasOne(aof => aof.Model)
                .WithMany(m => m.AmountOfSizes)
                .HasForeignKey(aof => aof.ModelId);
        }
    }
}