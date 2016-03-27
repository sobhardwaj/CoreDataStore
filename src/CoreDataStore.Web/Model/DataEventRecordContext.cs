using Microsoft.Data.Entity;

namespace CoreDataStore.Web.Model
{
    public class DataEventRecordContext : DbContext
    {
        public DbSet<DataEventRecord> DataEventRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DataEventRecord>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }


    }
}
