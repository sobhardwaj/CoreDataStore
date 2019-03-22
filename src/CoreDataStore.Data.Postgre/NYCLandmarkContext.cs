using CoreDataStore.Domain.Entities;
using CoreDataStore.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.Postgre
{
    public class NycLandmarkContext : DbContext
    {
        public NycLandmarkContext(DbContextOptions<NycLandmarkContext> options)
            : base(options)
        { }

        public NycLandmarkContext()
        {
        }

        public DbSet<LpcReport> LPCReports { get; set; }

        public DbSet<LpcLocation> LPCLocation { get; set; }

        public DbSet<LpcLamppost> LPCLamppost { get; set; }

        public DbSet<Landmark> Landmarks { get; set; }

        public DbSet<Pluto> Pluto { get; set; }

        public DbSet<AuditLog> AuditLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region LPC Report

            modelBuilder.Entity<LpcReport>().ToTable("LPCReport");
            modelBuilder.Entity<LpcReport>().HasKey(m => m.Id);
            modelBuilder.Entity<LpcReport>().Property(t => t.Architect).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<LpcReport>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(20);
            modelBuilder.Entity<LpcReport>().Property(t => t.ObjectType).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<LpcReport>().Property(t => t.LPNumber).HasColumnType("varchar").IsRequired().HasMaxLength(10);
            modelBuilder.Entity<LpcReport>().Property(t => t.LPCId).HasColumnType("varchar").IsRequired().HasMaxLength(10);
            modelBuilder.Entity<LpcReport>().Property(t => t.Name).HasColumnType("varchar").IsRequired();
            modelBuilder.Entity<LpcReport>().Property(t => t.PhotoURL).HasColumnType("varchar").HasMaxLength(500);
            modelBuilder.Entity<LpcReport>().Property(t => t.Style).HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<LpcReport>().Property(t => t.DateDesignated); //.HasColumnType("NpgsqlDate");

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
            modelBuilder.Entity<LpcLocation>().Property(t => t.Name).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            modelBuilder.Entity<LpcLocation>().Property(t => t.LPNumber).HasColumnType("varchar").HasMaxLength(10).IsRequired();
            modelBuilder.Entity<LpcLocation>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(13);
            modelBuilder.Entity<LpcLocation>().Property(t => t.ZipCode).HasColumnType("varchar").HasMaxLength(5);
            modelBuilder.Entity<LpcLocation>().Property(t => t.ObjectType).HasColumnType("varchar").HasMaxLength(50);
            //  builder.Entity<LpcLocation>().Property(t => t.LocationType).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Neighborhood).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Street).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Address).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)");
            modelBuilder.Entity<LpcLocation>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)");

            #endregion

            #region Landmark

            modelBuilder.Entity<Landmark>().ToTable("Landmark");
            modelBuilder.Entity<Landmark>().HasKey(m => m.Id);
            modelBuilder.Entity<Landmark>().Property(t => t.BoroughID).HasColumnType("varchar").HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.OBJECTID).IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.BOUNDARIES).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.DESIG_ADDR).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.HIST_DISTR).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.LAST_ACTIO).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<Landmark>().Property(t => t.LM_NAME).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.LP_NUMBER).HasColumnType("varchar").HasMaxLength(10);
            modelBuilder.Entity<Landmark>().Property(t => t.LM_TYPE).HasColumnType("varchar").HasMaxLength(19);
            modelBuilder.Entity<Landmark>().Property(t => t.NON_BLDG).HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Landmark>().Property(t => t.OTHER_HEAR).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.PLUTO_ADDR).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.PUBLIC_HEA).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.STATUS).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.STATUS_NOT).HasColumnType("varchar").HasMaxLength(200);
            modelBuilder.Entity<Landmark>().Property(t => t.CALEN_DATE).HasColumnType("date");
            modelBuilder.Entity<Landmark>().Property(t => t.DESIG_DATE).HasColumnType("date");
            modelBuilder.Entity<Landmark>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)").IsRequired();
            modelBuilder.Entity<Landmark>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)").IsRequired();

            //LPC Report(One) =>  Landmark(Many)
            modelBuilder.Entity<Landmark>()
                .HasOne(l => l.LPCReport)
                .WithMany(r => r.Landmarks)
                .HasForeignKey(l => l.LP_NUMBER)
                .HasPrincipalKey(r => r.LPNumber);

            #endregion

            #region Pluto

            modelBuilder.Entity<Pluto>().ToTable("PLUTO");
            modelBuilder.Entity<Pluto>().HasKey(m => m.Id);
            modelBuilder.Entity<Pluto>().Property(t => t.Id).HasColumnName("id");
            modelBuilder.Entity<Pluto>().Property(t => t.LandmarkName).HasColumnName("Landmark").HasMaxLength(100);
            modelBuilder.Entity<Pluto>().Property(t => t.BBL).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.Address).HasMaxLength(28);
            modelBuilder.Entity<Pluto>().Property(t => t.ZipCode).HasMaxLength(5);
            modelBuilder.Entity<Pluto>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)").IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)").IsRequired();

            #endregion

            #region Lamppost

            modelBuilder.Entity<LpcLamppost>().ToTable("LPCLamppost");
            modelBuilder.Entity<LpcLamppost>().HasKey(m => m.Id);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Type).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.SubType).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(20);
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)");
            modelBuilder.Entity<LpcLamppost>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)");

            #endregion

            modelBuilder.Entity<AuditLog>().ToTable("AuditLog");
            modelBuilder.Entity<AuditLog>().HasKey(m => m.Id);
            modelBuilder.Entity<AuditLog>().Property(t => t.UserName).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<AuditLog>().Property(t => t.ImportType).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<AuditLog>().Property(t => t.EventType).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuditLog>().Property(t => t.TableName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AuditLog>().Property(t => t.ColumnName).HasColumnType("varchar").HasMaxLength(50).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
