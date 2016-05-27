using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoreDataStore.Data.Sqlite
{
    public class DataEventRecordContext : DbContext
    {
        public DataEventRecordContext(DbContextOptions<DataEventRecordContext> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DataEventRecord>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  var connString = Config["SqliteConnectionString"];

            var connString = "Data Source=..\\..\\..\\CoreDataStore\\data\\coredatastore.sqlite";
            optionsBuilder.UseSqlite(connString);
        }

        public IConfiguration Config { get; set; }

        public DataEventRecordContext()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("config.json")
             //  .AddEnvironmentVariables()
               ;

            // var config = new Configuration()
            // .AddJsonFile("config.json")
            //.AddEnvironmentVariables();

            var config = builder.Build();
            Config = config;
        }

        public DbSet<DataEventRecord> DataEventRecords { get; set; }


    }
}
