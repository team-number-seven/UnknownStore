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
    public class SubCategoryConfiguration:IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder
                .ToTable("SubTypes");
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
                .WithMany(s => s.SubTypes)
                .HasForeignKey(sb => sb.TypeId);
            builder
                .HasOne(sb => sb.Size)
                .WithMany(sb => sb.SubTypes)
                .HasForeignKey(sb => sb.SizeId);
            builder
                .HasMany(sb => sb.Models)
                .WithOne(m => m.SubCategory)
                .HasForeignKey(m => m.SubTypeId);
        }
    }
}
