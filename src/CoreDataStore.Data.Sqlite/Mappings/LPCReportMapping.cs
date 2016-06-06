using CoreDataStore.Data.Conventions;
using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreDataStore.Data.Sqlite.Mappings
{
    public class LPCReportMapping : EntityMappingConfiguration<LPCReport>
    {
        //https://github.com/aspnet/EntityFramework/issues/2805

        public override void Map(EntityTypeBuilder<LPCReport> b)
        {
            b.Property(p => p.Name).HasMaxLength(200);
            b.Property(p => p.Architect).HasMaxLength(200);

        }
    }
}
