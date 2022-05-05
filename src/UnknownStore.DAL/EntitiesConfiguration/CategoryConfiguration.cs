using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class CategoryConfiguration:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .ToTable("Categories");
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .HasOne(c => c.AgeType)
                .WithMany(at => at.Types)
                .HasForeignKey(c => c.AgeTypeId);

            builder
                .HasMany(c => c.SubCategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryId);
        }
    }
}
