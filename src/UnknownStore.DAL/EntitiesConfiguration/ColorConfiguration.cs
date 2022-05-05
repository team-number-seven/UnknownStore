using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .ToTable("Colors");
            builder
                .HasKey(c => c.Id);
            builder
                .HasIndex(c => c.Title)
                .IsUnique();
            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}