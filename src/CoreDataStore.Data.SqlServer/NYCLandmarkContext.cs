using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreDataStore.Data.SqlServer
{
    public class NycLandmarkContext : DbContext
    {
        public string UserName { get; set; }

        public string ImportType { get; set; }

        public NycLandmarkContext(DbContextOptions<NycLandmarkContext> options) : base(options)
        { }

        public NycLandmarkContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region LPC Report

            modelBuilder.Entity<LpcReport>().ToTable("LPCReport");
            modelBuilder.Entity<LpcReport>().HasKey(m => m.Id);
            modelBuilder.Entity<LpcReport>().Property(t => t.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<LpcReport>().Property(t => t.Architect).HasMaxLength(200);
            modelBuilder.Entity<LpcReport>().Property(t => t.Borough).HasMaxLength(20);
            modelBuilder.Entity<LpcReport>().Property(t => t.ObjectType).HasMaxLength(50);
            modelBuilder.Entity<LpcReport>().Property(t => t.LPNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<LpcReport>().Property(t => t.LPCId).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<LpcReport>().Property(t => t.PhotoURL).HasMaxLength(500);
            modelBuilder.Entity<LpcReport>().Property(t => t.Street).HasMaxLength(200);
            modelBuilder.Entity<LpcReport>().Property(t => t.Style).HasMaxLength(100);

            //Shadow Properties
            //builder.Entity<LPCReport>().Property<DateTime>("Modified");

            // One to One LPCReport => LPCLocation
            modelBuilder.Entity<LpcReport>()
                .HasOne(t => t.LPCLocation)
                .WithOne(t => t.LPCReport)
                .HasPrincipalKey<LpcReport>(t => t.LPNumber)
                .HasForeignKey<LpcLocation>(t => t.LPNumber);

            #endregion

            #region LPC Location

            modelBuilder.Entity<LpcLocation>().ToTable("LPCLocation");
            modelBuilder.Entity<LpcLocation>().HasKey(m => m.Id);
            modelBuilder.Entity<LpcLocation>().Property(t => t.LPNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<LpcLocation>().Property(t => t.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<LpcLocation>().Property(t => t.BBL);
            modelBuilder.Entity<LpcLocation>().Property(t => t.ObjectType).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<LpcLocation>().Property(t => t.LocationType).HasMaxLength(50);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Street).HasMaxLength(255);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Address).HasMaxLength(255);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Neighborhood).HasMaxLength(100);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Borough).HasMaxLength(13);
            modelBuilder.Entity<LpcLocation>().Property(t => t.ZipCode).HasMaxLength(5);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Block);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Lot);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Latitude); //.HasPrecision(9, 6);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Longitude); //.HasPrecision(9, 6);


            //builder.Entity<LPCLocation>()
            //    .HasOne(t => t.LPCReport)
            //    .WithOne(t => t.LPCLocation)
            //    .HasPrincipalKey<LPCLocation>(t => t.LPNumber)
            //    .HasForeignKey<LPCReport>(t => t.LPNumber);

            #endregion

            #region Landmark

            modelBuilder.Entity<Landmark>().ToTable("Landmark");
            modelBuilder.Entity<Landmark>().HasKey(m => m.Id);
            modelBuilder.Entity<Landmark>().Property(t => t.BoroughID).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.BOUNDARIES).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.DESIG_ADDR).HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.HIST_DISTR).HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.LAST_ACTIO).HasMaxLength(50);
            modelBuilder.Entity<Landmark>().Property(t => t.LM_NAME).HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.LP_NUMBER).HasMaxLength(10);
            modelBuilder.Entity<Landmark>().Property(t => t.LM_TYPE).HasMaxLength(19);
            modelBuilder.Entity<Landmark>().Property(t => t.NON_BLDG).HasMaxLength(100);
            modelBuilder.Entity<Landmark>().Property(t => t.OTHER_HEAR).HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.PLUTO_ADDR).HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.PUBLIC_HEA).HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.STATUS).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.STATUS_NOT).HasMaxLength(200);

            modelBuilder.Entity<Landmark>()
                .HasOne(l => l.LPCReport)
                .WithMany(r => r.Landmarks)
                .HasForeignKey(l => l.LP_NUMBER)
                .HasPrincipalKey(r => r.LPNumber);

            #endregion

            #region Lamppost

            modelBuilder.Entity<LpcLamppost>().ToTable("LPCLamppost");
            modelBuilder.Entity<LpcLamppost>().HasKey(m => m.Id);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.PostId).IsRequired();
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Type).HasMaxLength(50);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.SubType).HasMaxLength(50);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Block);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Lot);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Borough).HasMaxLength(20);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Located).HasMaxLength(100);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Latitude);  //.HasPrecision(9, 6);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Longitude);  //.HasPrecision(9, 6);

            #endregion

            #region Pluto

            modelBuilder.Entity<Pluto>().ToTable("PLUTO");
            modelBuilder.Entity<Pluto>().HasKey(m => m.Id);
            modelBuilder.Entity<Pluto>().Property(t => t.Borough).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.Block).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.LandmarkName).HasColumnName("Landmark").HasMaxLength(100);
            modelBuilder.Entity<Pluto>().Property(t => t.Lot).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.BBL).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.Latitude); //.HasPrecision(9, 6).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.Longitude); //.HasPrecision(9, 6).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.OwnerName).HasMaxLength(21);
            modelBuilder.Entity<Pluto>().Property(t => t.ZipCode).HasMaxLength(5);

            #endregion

            modelBuilder.Entity<AuditLog>().ToTable("AuditLog");
            modelBuilder.Entity<AuditLog>().HasKey(m => m.Id);
            modelBuilder.Entity<AuditLog>().Property(t => t.UserName).HasMaxLength(50);
            modelBuilder.Entity<AuditLog>().Property(t => t.ImportType).HasMaxLength(50);
            modelBuilder.Entity<AuditLog>().Property(t => t.EventType).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuditLog>().Property(t => t.TableName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuditLog>().Property(t => t.ColumnName).HasMaxLength(50).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            //var modifiedEntries = ChangeTracker.Entries<IAuditableEntity>()
            //   .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            //foreach (EntityEntry<IAuditableEntity> entity in modifiedEntries)
            //{
            //    //entity.Property("Modified").CurrentValue = DateTime.UtcNow;
            //    //entity.Property("ObjectType").CurrentValue = "XXXXXXXX";
            //}

            base.SaveChanges();
            return 0;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //Set Audiable Entries
            var userId = UserName;
            return await base.SaveChangesAsync(cancellationToken);
        }


        public DbSet<LpcReport> LPCReports { get; set; }

        public DbSet<LpcLocation> LPCLocation { get; set; }

        public DbSet<LpcLamppost> LPCLamppost { get; set; }

        public DbSet<Landmark> Landmarks { get; set; }

        public DbSet<Pluto> Pluto { get; set; }

        public DbSet<AuditLog> AuditLog { get; set; }

        private IEnumerable<AuditLog> ApplyLoggingData(EntityEntry dbEntry)
        {
            var result = new List<AuditLog>();

            DateTime changeTime = DateTime.UtcNow;
            //string property = !string.IsNullOrEmpty(Property) ? Property : null;

            if (dbEntry.State == EntityState.Added)
            {
                var tableAttr = dbEntry.CurrentValues.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
                string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

                result.Add(new AuditLog()
                {
                    UserName = UserName,
                    ImportType = ImportType,
                    EventDateUtc = changeTime,
                    EventType = "A",
                    TableName = tableName.Split('_')[0],
                    RecordId = (int)dbEntry.CurrentValues.GetValue<object>("Id"),
                    ColumnName = "*ALL",
                    //NewValue = (dbEntry.CurrentValues.ToObject() is IAuditableEntity) ? (dbEntry.CurrentValues.ToObject() as IAuditableEntity).Describe(property) : dbEntry.CurrentValues.ToObject().ToString()
                });
            }
            else if (dbEntry.State == EntityState.Deleted)
            {
                var tableAttr = dbEntry.OriginalValues.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
                string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

                result.Add(new AuditLog()
                {
                    UserName = UserName,
                    ImportType = ImportType,
                    EventDateUtc = changeTime,
                    EventType = "D",
                    IsDeleted = true,
                    TableName = tableName.Split('_')[0],
                    RecordId = (int)dbEntry.OriginalValues.GetValue<object>("Id"),
                    ColumnName = "*ALL",
                    // OriginalValue = (dbEntry.OriginalValues.ToObject() is IAuditableEntity) ? (dbEntry.OriginalValues.ToObject() as IAuditableEntity).Describe(property) : dbEntry.OriginalValues.ToObject().ToString()
                });
            }
            else if (dbEntry.State == EntityState.Modified)
            {
                //var changedColumns = new List<string>();
                //foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                //{
                //    if (!object.Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
                //    {
                //        changedColumns.Add(propertyName);
                //    }
                //}

                var tableAttr = dbEntry.OriginalValues.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
                string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

                result.Add(new AuditLog()
                {
                    UserName = UserName,
                    ImportType = ImportType,
                    EventDateUtc = changeTime,
                    EventType = "M",
                    TableName = tableName.Split('_')[0],
                    RecordId = (int)dbEntry.CurrentValues.GetValue<object>("Id"),
                    // ColumnName = changedColumns.Aggregate((working, next) => working + "|" + next),
                    //OriginalValue = (dbEntry.OriginalValues.ToObject() is IAuditableEntity) ? (dbEntry.OriginalValues.ToObject() as IAuditableEntity).Describe(property) : dbEntry.OriginalValues.ToObject().ToString(),
                    //NewValue = (dbEntry.CurrentValues.ToObject() is IAuditableEntity) ? (dbEntry.CurrentValues.ToObject() as IAuditableEntity).Describe(property) : dbEntry.CurrentValues.ToObject().ToString(),
                });
            }
            else if (dbEntry.State == EntityState.Unchanged)
            {
                var tableAttr = dbEntry.OriginalValues.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;
                string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;
                result.Add(new AuditLog()
                {
                    UserName = UserName,
                    ImportType = ImportType,
                    EventDateUtc = changeTime,
                    EventType = "A",
                    TableName = tableName.Split('_')[0],
                    RecordId = (int)dbEntry.OriginalValues.GetValue<object>("Id"),
                    ColumnName = "*ALL",
                    // NewValue = (dbEntry.OriginalValues.ToObject() is IAuditableEntity) ? (dbEntry.OriginalValues.ToObject() as IAuditableEntity).Describe(property) : dbEntry.OriginalValues.ToObject().ToString()
                });
            }

            return result;
        }

    }
}
