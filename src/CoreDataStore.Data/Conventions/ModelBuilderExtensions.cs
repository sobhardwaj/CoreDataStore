using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreDataStore.Data.Conventions
{
    public static class ModelBuilderExtensions
    {
        public static void MaxLengthConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(200);
                }
            }
        }
    }

}
