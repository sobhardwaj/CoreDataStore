using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreDataStore.Data.SqlServer.Mappings
{
    public class LpcReportMapping : IEntityTypeConfiguration<LpcReport>
    {
        public void Configure(EntityTypeBuilder<LpcReport> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(t => t.Name).HasMaxLength(200).IsRequired();
            builder.Property(t => t.Architect).HasMaxLength(200);
            builder.Property(t => t.Borough).HasMaxLength(20);
            builder.Property(t => t.ObjectType).HasMaxLength(50);
            builder.Property(t => t.LPNumber).HasMaxLength(10).IsRequired();
            builder.Property(t => t.LPCId).HasMaxLength(10).IsRequired();
            builder.Property(t => t.PhotoURL).HasMaxLength(500);
            builder.Property(t => t.Style).HasMaxLength(100);

            // Shadow Properties
            // builder.Entity<LPCReport>().Property<DateTime>("Modified");
        }
    }
}
