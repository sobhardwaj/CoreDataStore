using CoreDataStore.Data.Conventions;
using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.Sqlite
{
    public class DataEventRecordContext : DbContext
    {
        public DataEventRecordContext(DbContextOptions<DataEventRecordContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RemovePluralizingTableNameConvention();

            builder.Entity<DataEventRecord>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }


        public DbSet<DataEventRecord> DataEventRecords { get; set; }

    }
}
