using System;
using CoreDataStore.Data.Conventions;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

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
            builder.Entity<LPCReport>().Property(t => t.PhotoURL).HasMaxLength(500);
            builder.Entity<LPCReport>().Property(t => t.Style).HasMaxLength(100);

            //Shadow Properties
            //builder.Entity<LPCReport>().Property<DateTime>("Modified");

            builder.Entity<Landmark>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }

        //http://stackoverflow.com/questions/34578573/entity-framework-7-audit-log
        //http://stackoverflow.com/questions/37210914/changetracker-entries-currentvalue-equals-originalvalue-in-ef7-ef-core
        //http://www.c-sharpcorner.com/article/shadow-properties-in-entity-framework-7/

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var modifiedBidEntries = ChangeTracker.Entries<IAuditableEntity>()
                 .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry<IAuditableEntity> entity in modifiedBidEntries)
            {
               // entity.Property("Modified").CurrentValue = DateTime.UtcNow;
              // entity.Property("ObjectType").CurrentValue = "XXXXXXXX";
            }

            return base.SaveChanges();
        }

        public DbSet<LPCReport> LPCReports { get; set; }

        public DbSet<Landmark> Landmarks { get; set; }
        

    }
}
