using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class MainImageConfiguration : IEntityTypeConfiguration<MainImage>
    {
        public void Configure(EntityTypeBuilder<MainImage> builder)
        {
            builder
                .ToTable("MainImages");
            builder
                .HasKey(mi => mi.Id);
            builder
                .HasIndex(mi => mi.Path)
                .IsUnique();
            builder
                .Property(mi => mi.Format)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(mi => mi.Path)
                .HasMaxLength(500)
                .IsRequired();
            builder
                .HasOne(mi => mi.Model)
                .WithOne(m => m.MainImage)
                .HasForeignKey<MainImage>(mi => mi.ModelId);
        }
    }
}