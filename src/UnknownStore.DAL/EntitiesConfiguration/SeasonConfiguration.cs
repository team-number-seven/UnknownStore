using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder
                .ToTable("Seasons");
            builder
                .HasKey(s => s.Id);
            builder
                .HasIndex(s => s.Title)
                .IsUnique();
            builder
                .Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .HasMany(s => s.Models)
                .WithOne(m => m.Season)
                .HasForeignKey(m => m.SeasonId);
        }
    }
}