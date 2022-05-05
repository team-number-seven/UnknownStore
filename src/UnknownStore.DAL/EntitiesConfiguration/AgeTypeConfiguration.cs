using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class AgeTypeConfiguration : IEntityTypeConfiguration<AgeType>
    {
        public void Configure(EntityTypeBuilder<AgeType> builder)
        {
            builder
                .ToTable("AgeTypes");
            builder
                .HasKey(at => at.Id);
            builder
                .HasIndex(at => at.Title)
                .IsUnique();
            builder
                .Property(at => at.Title)
                .IsRequired()
                .HasMaxLength(25);
            builder
                .HasMany(at => at.Types)
                .WithOne(t => t.AgeType)
                .HasForeignKey(t => t.AgeTypeId);
        }
    }
}