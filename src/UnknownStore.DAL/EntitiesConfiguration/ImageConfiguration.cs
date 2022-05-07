using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
            builder
                .HasKey(i => i.Id);
            builder
                .HasIndex(i => i.Path)
                .IsUnique();
            builder
                .Property(i => i.Format)
                .HasMaxLength(20)
                .IsRequired();
            builder
                .Property(i => i.Path)
                .HasMaxLength(500)
                .IsRequired();
            builder
                .HasOne(i => i.Model)
                .WithMany(m => m.Images)
                .HasForeignKey(i => i.ModelId);
        }
    }
}