﻿using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreDataStore.Data.SqlServer.Mappings
{
    public class LPCLocationMapping : IEntityTypeConfiguration<LpcLocation>
    {
        public void Configure(EntityTypeBuilder<LpcLocation> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
            builder.Property(t => t.LPNumber).HasMaxLength(10).IsRequired();
            builder.Property(t => t.Borough).HasMaxLength(13);
            builder.Property(t => t.ZipCode).HasMaxLength(5);
            builder.Property(t => t.ObjectType).HasMaxLength(50);
            builder.Property(t => t.Latitude);  //.HasPrecision(9, 6);
            builder.Property(t => t.Longitude); //.HasPrecision(9, 6);
        }
    }
}
