using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder
                .ToTable("Sizes");
            builder
                .HasKey(s => s.Id);
            builder
                .Property(s => s.Standard)
                .IsRequired()
                .HasMaxLength(15);
            builder
                .HasOne(s => s.SubCategory)
                .WithOne(sb => sb.Size)
                .HasForeignKey<Size>(s => s.SubCategoryId);

        }
    }
}