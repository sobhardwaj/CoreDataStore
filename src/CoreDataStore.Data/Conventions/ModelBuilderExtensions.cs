using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreDataStore.Data.Conventions
{
    public static class ModelBuilderExtensions
    {
        //http://stackoverflow.com/questions/37493095/entity-framework-core-rc2-table-name-pluralization/37502978#37502978

        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }


       // https://github.com/rowanmiller/Demo-EFCore/blob/master/CompletedSourceCode/Conventions/Program.cs

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
