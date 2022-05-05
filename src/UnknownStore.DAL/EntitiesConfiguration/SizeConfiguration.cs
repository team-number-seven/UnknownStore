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
    public class SizeConfiguration:IEntityTypeConfiguration<Size>
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
                .HasMany(s => s.SubTypes)
                .WithOne(sb => sb.Size)
                .HasForeignKey(sb => sb.SizeId);
        }
    }
}
