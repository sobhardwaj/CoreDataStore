using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.Postgre
{
    public class NYCLandmarkContext : DbContext
    {
        public NYCLandmarkContext(DbContextOptions<NYCLandmarkContext> options)
            : base(options)
        { }

        public NYCLandmarkContext()
        {
        }

        public DbSet<LPCReport> LPCReports { get; set; }

        public DbSet<LPCLocation> LPCLocation { get; set; }

        public DbSet<LPCLamppost> LPCLamppost { get; set; }

        public DbSet<Landmark> Landmarks { get; set; }

        public DbSet<Pluto> Pluto { get; set; }

        public DbSet<AuditLog> AuditLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region LPC Report

            builder.Entity<LPCReport>().ToTable("LPCReport");
            builder.Entity<LPCReport>().HasKey(m => m.Id);
            builder.Entity<LPCReport>().Property(t => t.Architect).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LPCReport>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(20);
            builder.Entity<LPCReport>().Property(t => t.ObjectType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LPCReport>().Property(t => t.LPNumber).HasColumnType("varchar").IsRequired().HasMaxLength(10);
            builder.Entity<LPCReport>().Property(t => t.LPCId).HasColumnType("varchar").IsRequired().HasMaxLength(10);
            builder.Entity<LPCReport>().Property(t => t.Name).HasColumnType("varchar").IsRequired();
            builder.Entity<LPCReport>().Property(t => t.PhotoURL).HasColumnType("varchar").HasMaxLength(500);
            builder.Entity<LPCReport>().Property(t => t.Style).HasColumnType("varchar").HasMaxLength(100);
            builder.Entity<LPCReport>().Property(t => t.DateDesignated); //.HasColumnType("NpgsqlDate");

            // One to One LPCReport => LPCLocation
            builder.Entity<LPCReport>()
                .HasOne(t => t.LPCLocation)
                .WithOne(t => t.LPCReport)
                .HasPrincipalKey<LPCReport>(t => t.LPNumber)
                .HasForeignKey<LPCLocation>(t => t.LPNumber);

            #endregion

            #region LPC Location

            builder.Entity<LPCLocation>().ToTable("LPCLocation");
            builder.Entity<LPCLocation>().HasKey(m => m.Id);
            builder.Entity<LPCLocation>().Property(t => t.Name).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Entity<LPCLocation>().Property(t => t.LPNumber).HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Entity<LPCLocation>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(13);
            builder.Entity<LPCLocation>().Property(t => t.ZipCode).HasColumnType("varchar").HasMaxLength(5);
            builder.Entity<LPCLocation>().Property(t => t.ObjectType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LPCLocation>().Property(t => t.LocationType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LPCLocation>().Property(t => t.Neighborhood).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LPCLocation>().Property(t => t.Street).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LPCLocation>().Property(t => t.Address).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LPCLocation>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)");
            builder.Entity<LPCLocation>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)");

            //builder.Entity<LPCLocation>()
            //    .HasOne(t => t.LPCReport)
            //    .WithOne(t => t.LPCLocation)
            //    .HasPrincipalKey<LPCLocation>(t => t.LPNumber)
            //    .HasForeignKey<LPCReport>(t => t.LPNumber);

            #endregion

            #region Landmark

            builder.Entity<Landmark>().ToTable("Landmark");
            builder.Entity<Landmark>().HasKey(m => m.Id);
            builder.Entity<Landmark>().Property(t => t.BoroughID).HasColumnType("varchar").HasMaxLength(2).IsRequired();
            builder.Entity<Landmark>().Property(t => t.OBJECTID).IsRequired();
            builder.Entity<Landmark>().Property(t => t.BOUNDARIES).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Entity<Landmark>().Property(t => t.DESIG_ADDR).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.HIST_DISTR).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.LAST_ACTIO).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<Landmark>().Property(t => t.LM_NAME).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.LP_NUMBER).HasColumnType("varchar").HasMaxLength(10);
            builder.Entity<Landmark>().Property(t => t.LM_TYPE).HasColumnType("varchar").HasMaxLength(19);
            builder.Entity<Landmark>().Property(t => t.NON_BLDG).HasColumnType("varchar").HasMaxLength(100);
            builder.Entity<Landmark>().Property(t => t.OTHER_HEAR).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.PLUTO_ADDR).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.PUBLIC_HEA).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.STATUS).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Entity<Landmark>().Property(t => t.STATUS_NOT).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<Landmark>().Property(t => t.CALEN_DATE).HasColumnType("date");
            builder.Entity<Landmark>().Property(t => t.DESIG_DATE).HasColumnType("date");
            builder.Entity<Landmark>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)").IsRequired();
            builder.Entity<Landmark>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)").IsRequired();

            //LPC Report(One) =>  Landmark(Many)
            builder.Entity<Landmark>()
                .HasOne(l => l.LPCReport)
                .WithMany(r => r.Landmarks)
                .HasForeignKey(l => l.LP_NUMBER)
                .HasPrincipalKey(r => r.LPNumber);

            #endregion

            #region Pluto

            builder.Entity<Pluto>().ToTable("PLUTO");
            builder.Entity<Pluto>().HasKey(m => m.Id);
            builder.Entity<Pluto>().Property(t => t.Id).HasColumnName("id");
            builder.Entity<Pluto>().Property(t => t.LandmarkName).HasColumnName("Landmark").HasMaxLength(100);
            builder.Entity<Pluto>().Property(t => t.BBL).IsRequired();
            builder.Entity<Pluto>().Property(t => t.Address).HasMaxLength(28);
            builder.Entity<Pluto>().Property(t => t.ZipCode).HasMaxLength(5);
            builder.Entity<Pluto>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)").IsRequired();
            builder.Entity<Pluto>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)").IsRequired();

            #endregion

            #region Lamppost

            builder.Entity<LPCLamppost>().ToTable("LPCLamppost");
            builder.Entity<LPCLamppost>().HasKey(m => m.Id);
            builder.Entity<LPCLamppost>().Property(t => t.Type).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LPCLamppost>().Property(t => t.SubType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LPCLamppost>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(20);
            builder.Entity<LPCLamppost>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)");
            builder.Entity<LPCLamppost>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)");

            #endregion

            builder.Entity<AuditLog>().ToTable("AuditLog");
            builder.Entity<AuditLog>().HasKey(m => m.Id);
            builder.Entity<AuditLog>().Property(t => t.UserName).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<AuditLog>().Property(t => t.ImportType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<AuditLog>().Property(t => t.EventType).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Entity<AuditLog>().Property(t => t.TableName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Entity<AuditLog>().Property(t => t.ColumnName).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            base.OnModelCreating(builder);
        }
    }
}
