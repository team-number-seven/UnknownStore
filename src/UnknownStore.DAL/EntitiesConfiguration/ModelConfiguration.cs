using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder
                .ToTable("Models");
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Price)
                .IsRequired();
            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .Property(m => m.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId);

            builder
                .HasOne(m => m.Factory)
                .WithMany(f => f.Models)
                .HasForeignKey(m => m.FactoryId);
            builder
                .HasOne(m => m.SubCategory)
                .WithMany(sb => sb.Models)
                .HasForeignKey(m => m.SubCategoryId);

            builder
                .HasOne(m => m.MainImage)
                .WithOne(i => i.Model)
                .HasForeignKey<MainImage>(i => i.ModelId);
            builder
                .HasOne(m => m.Color)
                .WithMany(c => c.Models)
                .HasForeignKey(m => m.ColorId);
            builder
                .HasMany(m => m.AmountOfSizes)
                .WithOne(aof => aof.Model)
                .HasForeignKey(m => m.ModelId);
            builder
                .HasMany(m => m.ModelData)
                .WithOne(md => md.Model)
                .HasForeignKey(md => md.ModelId);
            builder
                .HasOne(m => m.Season)
                .WithMany(s => s.Models)
                .HasForeignKey(m => m.SeasonId);

            builder
                .HasMany(m => m.Images)
                .WithOne(i => i.Model)
                .HasForeignKey(m => m.ModelId);
        }
    }
}