using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleBloggingApp.Entities;
using SimpleBloggingApp.Infrastructure;

namespace SimpleBloggingApp.Mappings
{
    public class BlogConfiguration : EntityMappingConfiguration<Blog>
    {
        public override void Map(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Url).ForSqliteHasColumnType("varchar(250)");
        }
    }
}


