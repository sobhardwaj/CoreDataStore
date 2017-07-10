﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CoreDataStore.Data.Conventions;
using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoreDataStore.Data.SqlServer
{
    public class NYCLandmarkContext : DbContext
    {
        public string UserName { get; set; }

        public string ImportType { get; set; }


        public NYCLandmarkContext(DbContextOptions<NYCLandmarkContext> options) : base(options)
        { }

        public NYCLandmarkContext()
        {
        }


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

   

            builder.Entity<LPCLocation>().HasKey(m => m.Id);
            builder.Entity<LPCLocation>().Property(t => t.LPNumber).HasMaxLength(10).IsRequired();
            builder.Entity<LPCLocation>().Property(t => t.Name).HasMaxLength(200).IsRequired();
            builder.Entity<LPCLocation>().Property(t => t.BBL);
            builder.Entity<LPCLocation>().Property(t => t.ObjectType).HasMaxLength(50).IsRequired();
            builder.Entity<LPCLocation>().Property(t => t.Street).HasMaxLength(255);
            builder.Entity<LPCLocation>().Property(t => t.Address).HasMaxLength(255);
            builder.Entity<LPCLocation>().Property(t => t.Neighborhood).HasMaxLength(100);
            builder.Entity<LPCLocation>().Property(t => t.Borough).HasMaxLength(13);
            builder.Entity<LPCLocation>().Property(t => t.ZipCode).HasMaxLength(5);
            builder.Entity<LPCLocation>().Property(t => t.Block);
            builder.Entity<LPCLocation>().Property(t => t.Lot);
            builder.Entity<LPCLocation>().Property(t => t.Latitude).HasPrecision(9, 6);
            builder.Entity<LPCLocation>().Property(t => t.Longitude).HasPrecision(9, 6);



            builder.Entity<LPCLamppost>().HasKey(m => m.Id);
            builder.Entity<LPCLamppost>().Property(t => t.PostId).IsRequired();
            builder.Entity<LPCLamppost>().Property(t => t.Type).HasMaxLength(50);
            builder.Entity<LPCLamppost>().Property(t => t.SubType).HasMaxLength(50);
            builder.Entity<LPCLamppost>().Property(t => t.Block);
            builder.Entity<LPCLamppost>().Property(t => t.Lot);
            builder.Entity<LPCLamppost>().Property(t => t.Borough).HasMaxLength(20);
            builder.Entity<LPCLamppost>().Property(t => t.Located).HasMaxLength(100);
            builder.Entity<LPCLamppost>().Property(t => t.Latitude).HasPrecision(9, 6);
            builder.Entity<LPCLamppost>().Property(t => t.Longitude).HasPrecision(9, 6);


            builder.Entity<Landmark>().HasKey(m => m.Id);
            builder.Entity<Landmark>().Property(t => t.BoroughID).HasMaxLength(2).IsRequired();
            builder.Entity<Landmark>().Property(t => t.BOUNDARIES).HasMaxLength(50).IsRequired();
            builder.Entity<Landmark>().Property(t => t.DESIG_ADDR).HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.HIST_DISTR).HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.LAST_ACTIO).HasMaxLength(50);
            builder.Entity<Landmark>().Property(t => t.LM_NAME).HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.LP_NUMBER).HasMaxLength(10);
            builder.Entity<Landmark>().Property(t => t.LM_TYPE).HasMaxLength(19);
            builder.Entity<Landmark>().Property(t => t.NON_BLDG).HasMaxLength(100);
            builder.Entity<Landmark>().Property(t => t.OTHER_HEAR).HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.PLUTO_ADDR).HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.PUBLIC_HEA).HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.STATUS).HasMaxLength(50).IsRequired();
            builder.Entity<Landmark>().Property(t => t.STATUS_NOT).HasMaxLength(200);

            builder.Entity<Landmark>()
                .HasOne(l => l.LPCReport)
                .WithMany(r => r.Landmarks)
                .HasForeignKey(l => l.LP_NUMBER)
                .HasPrincipalKey(r => r.LPNumber);


            builder.Entity<Landmark>()
                .HasOne(p => p.Pluto)
                .WithOne(l => l.Landmark)
                .HasForeignKey<Pluto>(p => p.BBL)
                .HasPrincipalKey<Landmark>(l => l.BBL);


            builder.Entity<Pluto>().HasKey(m => m.Id);
            builder.Entity<Pluto>().Property(t => t.Borough).HasMaxLength(2).IsRequired();
            builder.Entity<Pluto>().Property(t => t.Block).IsRequired();
            builder.Entity<Pluto>().Property(t => t.LandmarkName).HasColumnName("Landmark").HasMaxLength(100);
            builder.Entity<Pluto>().Property(t => t.Lot).IsRequired();
            builder.Entity<Pluto>().Property(t => t.BBL).IsRequired();
            builder.Entity<Pluto>().Property(t => t.Latitude).HasPrecision(9, 6).IsRequired();
            builder.Entity<Pluto>().Property(t => t.Longitude).HasPrecision(9, 6).IsRequired();
            builder.Entity<Pluto>().Property(t => t.OwnerName).HasMaxLength(21);
            builder.Entity<Pluto>().Property(t => t.ZipCode).HasMaxLength(5);

            builder.Entity<AuditLog>().ToTable("AuditLog");
            builder.Entity<AuditLog>().HasKey(m => m.Id);
            builder.Entity<AuditLog>().Property(t => t.UserName).HasMaxLength(50);
            builder.Entity<AuditLog>().Property(t => t.ImportType).HasMaxLength(50);
            builder.Entity<AuditLog>().Property(t => t.EventType).HasMaxLength(50).IsRequired();
            builder.Entity<AuditLog>().Property(t => t.TableName).HasMaxLength(50).IsRequired();
            builder.Entity<AuditLog>().Property(t => t.ColumnName).HasMaxLength(50).IsRequired();

            base.OnModelCreating(builder);
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


        public DbSet<LPCReport> LPCReports { get; set; }

        public DbSet<LPCLocation> LPCLocation { get; set; }

        public DbSet<LPCLamppost> LPCLamppost { get; set; }

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
