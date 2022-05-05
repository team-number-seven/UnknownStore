using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder
                .ToTable("SubCategories");
            builder
                .HasKey(sb => sb.Id);
            builder
                .HasIndex(sb => sb.Title)
                .IsUnique();
            builder
                .Property(sb => sb.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .HasOne(sb => sb.Category)
                .WithMany(s => s.SubCategories)
                .HasForeignKey(sb => sb.CategoryId);
            builder
                .HasOne(sb => sb.Size)
                .WithMany(sb => sb.SubCategories)
                .HasForeignKey(sb => sb.SizeId);

            builder
                .HasMany(sb => sb.Models)
                .WithOne(m => m.SubCategory)
                .HasForeignKey(m => m.SubCategoryId);
        }
    }
}