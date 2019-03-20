using CoreDataStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDataStore.Data.Sqlite
{
    public class NycLandmarkContext : DbContext
    {
        public NycLandmarkContext(DbContextOptions<NycLandmarkContext> options)
            : base(options)
        {
        }

        public DbSet<LpcReport> LPCReports { get; set; }

        public DbSet<LPCLocation> LPCLocation { get; set; }

        public DbSet<Landmark> Landmarks { get; set; }

        public DbSet<Pluto> Pluto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region LPC Report

            builder.Entity<LpcReport>().ToTable("LPCReport");
            builder.Entity<LpcReport>().HasKey(m => m.Id);
            builder.Entity<LpcReport>().Property(t => t.Name).HasMaxLength(200).IsRequired();
            builder.Entity<LpcReport>().Property(t => t.Architect).HasMaxLength(200);
            builder.Entity<LpcReport>().Property(t => t.Borough).HasMaxLength(20);
            builder.Entity<LpcReport>().Property(t => t.ObjectType).HasMaxLength(50);
            builder.Entity<LpcReport>().Property(t => t.LPNumber).HasMaxLength(10).IsRequired();
            builder.Entity<LpcReport>().Property(t => t.LPCId).HasMaxLength(10).IsRequired();
            builder.Entity<LpcReport>().Property(t => t.PhotoURL).HasMaxLength(500);
            builder.Entity<LpcReport>().Property(t => t.Street).HasMaxLength(500);
            builder.Entity<LpcReport>().Property(t => t.Style).HasMaxLength(100);

            #endregion

            #region LPC Location

            builder.Entity<LPCLocation>().ToTable("LPCLocation");
            builder.Entity<LPCLocation>().HasKey(m => m.Id);
            builder.Entity<LPCLocation>().Property(t => t.Name);
            builder.Entity<LPCLocation>().Property(t => t.LPNumber);
            builder.Entity<LPCLocation>().Property(t => t.Borough);
            builder.Entity<LPCLocation>().Property(t => t.ZipCode);
            builder.Entity<LPCLocation>().Property(t => t.ObjectType);
            builder.Entity<LPCLocation>().Property(t => t.LocationType);
            builder.Entity<LPCLocation>().Property(t => t.Neighborhood);
            builder.Entity<LPCLocation>().Property(t => t.Street);
            builder.Entity<LPCLocation>().Property(t => t.Address);
            builder.Entity<LPCLocation>().Property(t => t.Latitude);
            builder.Entity<LPCLocation>().Property(t => t.Longitude);

            builder.Entity<LPCLocation>()
                .HasOne(t => t.LPCReport)
                .WithOne(t => t.LPCLocation)
                .HasPrincipalKey<LPCLocation>(t => t.LPNumber)
                .HasForeignKey<LpcReport>(t => t.LPNumber);

            #endregion

            #region Landmark

            builder.Entity<Landmark>().ToTable("Landmark");
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

            #endregion

            #region Pluto

            builder.Entity<Pluto>().ToTable("PLUTO");
            builder.Entity<Pluto>().HasKey(m => m.Id);
            builder.Entity<Pluto>().Property(t => t.BBL).IsRequired();
            builder.Entity<Pluto>().Property(t => t.LandmarkName).HasColumnName("Landmark").HasMaxLength(100);
            builder.Entity<Pluto>().Property(t => t.Latitude);  //.HasPrecision(9, 6).IsRequired();
            builder.Entity<Pluto>().Property(t => t.Longitude);  //.HasPrecision(9, 6).IsRequired();
            builder.Entity<Pluto>().Property(t => t.ZipCode).HasMaxLength(5);

            #endregion

            base.OnModelCreating(builder);
        }
    }
}
