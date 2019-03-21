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

        public DbSet<LpcLocation> LPCLocation { get; set; }

        public DbSet<Landmark> Landmarks { get; set; }

        public DbSet<Pluto> Pluto { get; set; }

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
            modelBuilder.Entity<LpcReport>().Property(t => t.Street).HasMaxLength(500);
            modelBuilder.Entity<LpcReport>().Property(t => t.Style).HasMaxLength(100);

            #endregion

            #region LPC Location

            modelBuilder.Entity<LpcLocation>().ToTable("LPCLocation");
            modelBuilder.Entity<LpcLocation>().HasKey(m => m.Id);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Name);
            modelBuilder.Entity<LpcLocation>().Property(t => t.LPNumber);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Borough);
            modelBuilder.Entity<LpcLocation>().Property(t => t.ZipCode);
            modelBuilder.Entity<LpcLocation>().Property(t => t.ObjectType);
            modelBuilder.Entity<LpcLocation>().Property(t => t.LocationType);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Neighborhood);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Street);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Address);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Latitude);
            modelBuilder.Entity<LpcLocation>().Property(t => t.Longitude);

            modelBuilder.Entity<LpcLocation>()
                .HasOne(t => t.LPCReport)
                .WithOne(t => t.LPCLocation)
                .HasPrincipalKey<LpcLocation>(t => t.LPNumber)
                .HasForeignKey<LpcReport>(t => t.LPNumber);

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

            #region Pluto

            modelBuilder.Entity<Pluto>().ToTable("PLUTO");
            modelBuilder.Entity<Pluto>().HasKey(m => m.Id);
            modelBuilder.Entity<Pluto>().Property(t => t.BBL).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.LandmarkName).HasColumnName("Landmark").HasMaxLength(100);
            modelBuilder.Entity<Pluto>().Property(t => t.Latitude);  //.HasPrecision(9, 6).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.Longitude);  //.HasPrecision(9, 6).IsRequired();
            modelBuilder.Entity<Pluto>().Property(t => t.ZipCode).HasMaxLength(5);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
