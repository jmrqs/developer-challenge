﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SaleDate).IsRequired().HasMaxLength(50);
        builder.Property(u => u.CustomerId).IsRequired().HasMaxLength(100);
        builder.Property(u => u.BranchId).IsRequired().HasMaxLength(100);
        builder.Property(u => u.TotalAmount).IsRequired().HasMaxLength(100);

        builder.Property(u => u.IsCancelled)
            .HasConversion<string>()
            .HasMaxLength(20);
    }
}
