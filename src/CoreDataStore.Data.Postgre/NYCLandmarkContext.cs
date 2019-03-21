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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region LPC Report

            builder.Entity<LpcReport>().ToTable("LPCReport");
            builder.Entity<LpcReport>().HasKey(m => m.Id);
            builder.Entity<LpcReport>().Property(t => t.Architect).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LpcReport>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(20);
            builder.Entity<LpcReport>().Property(t => t.ObjectType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LpcReport>().Property(t => t.LPNumber).HasColumnType("varchar").IsRequired().HasMaxLength(10);
            builder.Entity<LpcReport>().Property(t => t.LPCId).HasColumnType("varchar").IsRequired().HasMaxLength(10);
            builder.Entity<LpcReport>().Property(t => t.Name).HasColumnType("varchar").IsRequired();
            builder.Entity<LpcReport>().Property(t => t.PhotoURL).HasColumnType("varchar").HasMaxLength(500);
            builder.Entity<LpcReport>().Property(t => t.Style).HasColumnType("varchar").HasMaxLength(100);
            builder.Entity<LpcReport>().Property(t => t.DateDesignated); //.HasColumnType("NpgsqlDate");

            // One to One LPCReport => LPCLocation
            builder.Entity<LpcReport>()
                .HasOne(t => t.LPCLocation)
                .WithOne(t => t.LPCReport)
                .HasPrincipalKey<LpcReport>(t => t.LPNumber)
                .HasForeignKey<LpcLocation>(t => t.LPNumber);

            #endregion

            #region LPC Location

            builder.Entity<LpcLocation>().ToTable("LPCLocation");
            builder.Entity<LpcLocation>().HasKey(m => m.Id);
            builder.Entity<LpcLocation>().Property(t => t.Name).HasColumnType("varchar").HasMaxLength(200).IsRequired();
            builder.Entity<LpcLocation>().Property(t => t.LPNumber).HasColumnType("varchar").HasMaxLength(10).IsRequired();
            builder.Entity<LpcLocation>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(13);
            builder.Entity<LpcLocation>().Property(t => t.ZipCode).HasColumnType("varchar").HasMaxLength(5);
            builder.Entity<LpcLocation>().Property(t => t.ObjectType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LpcLocation>().Property(t => t.LocationType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LpcLocation>().Property(t => t.Neighborhood).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LpcLocation>().Property(t => t.Street).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LpcLocation>().Property(t => t.Address).HasColumnType("varchar").HasMaxLength(200);
            builder.Entity<LpcLocation>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)");
            builder.Entity<LpcLocation>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)");

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

            builder.Entity<LpcLamppost>().ToTable("LPCLamppost");
            builder.Entity<LpcLamppost>().HasKey(m => m.Id);
            builder.Entity<LpcLamppost>().Property(t => t.Type).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LpcLamppost>().Property(t => t.SubType).HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<LpcLamppost>().Property(t => t.Borough).HasColumnType("varchar").HasMaxLength(20);
            builder.Entity<LpcLamppost>().Property(t => t.Latitude).HasColumnType("decimal(9, 6)");
            builder.Entity<LpcLamppost>().Property(t => t.Longitude).HasColumnType("decimal(9, 6)");

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
