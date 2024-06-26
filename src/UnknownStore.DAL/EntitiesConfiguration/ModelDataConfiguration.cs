﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnknownStore.DAL.Entities.Store;

namespace UnknownStore.DAL.EntitiesConfiguration
{
    public class ModelDataConfiguration : IEntityTypeConfiguration<ModelData>
    {
        public void Configure(EntityTypeBuilder<ModelData> builder)
        {
            builder
                .ToTable("ModelsData");
            builder
                .HasKey(md => md.Id);
            builder
                .Property(md => md.Key)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(md => md.Value)
                .IsRequired()
                .HasMaxLength(100);
            builder
                .HasOne(md => md.Model)
                .WithMany(m => m.ModelData)
                .HasForeignKey(md => md.ModelId);
        }
    }
}