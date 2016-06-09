using CoreDataStore.Data.Conventions;
using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.SqlServer
{
    public class NYCLandmarkContext : DbContext
    {
        public NYCLandmarkContext(DbContextOptions<NYCLandmarkContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RemovePluralizingTableNameConvention();

            builder.Entity<LPCReport>().HasKey(m => m.Id);
            builder.Entity<LPCReport>().Property(t => t.Name).HasMaxLength(200).IsRequired();
            builder.Entity<LPCReport>().Property(t => t.Architect).HasMaxLength(200);
            builder.Entity<LPCReport>().Property(t => t.Borough).HasMaxLength(20);
            builder.Entity<LPCReport>().Property(t => t.ObjectType).HasMaxLength(50);
            builder.Entity<LPCReport>().Property(t => t.LPNumber).HasMaxLength(10).IsRequired();
            builder.Entity<LPCReport>().Property(t => t.LPCId).HasMaxLength(10).IsRequired();


            builder.Entity<Landmark>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }

        public DbSet<LPCReport> LPCReports { get; set; }

        public DbSet<Landmark> Landmarks { get; set; }
        

    }
}
