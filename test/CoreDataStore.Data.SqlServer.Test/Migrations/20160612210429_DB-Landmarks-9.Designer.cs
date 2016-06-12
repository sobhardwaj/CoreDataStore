using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreDataStore.Data.SqlServer;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    [DbContext(typeof(NYCLandmarkContext))]
    [Migration("20160612210429_DB-Landmarks-9")]
    partial class DBLandmarks9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreDataStore.Domain.Entities.Landmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BBL");

                    b.Property<long>("BIN_NUMBER");

                    b.Property<int>("BLOCK");

                    b.Property<string>("BOUNDARIES")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("BoroughID")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 2);

                    b.Property<string>("CALEN_DATE");

                    b.Property<bool>("COUNT_BLDG");

                    b.Property<string>("DESIG_ADDR");

                    b.Property<string>("DESIG_DATE");

                    b.Property<string>("HIST_DISTR");

                    b.Property<string>("LAST_ACTIO");

                    b.Property<string>("LM_NAME");

                    b.Property<string>("LM_TYPE");

                    b.Property<int>("LOT");

                    b.Property<string>("LP_NUMBER")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<bool>("MOST_CURRE");

                    b.Property<string>("NON_BLDG");

                    b.Property<string>("OTHER_HEAR")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("PLUTO_ADDR")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("PUBLIC_HEA")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<bool>("SECND_BLDG");

                    b.Property<string>("STATUS")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("STATUS_NOT")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<bool>("VACANT_LOT");

                    b.HasKey("Id");

                    b.ToTable("Landmark");
                });

            modelBuilder.Entity("CoreDataStore.Domain.Entities.LPCReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Architect")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Borough")
                        .HasAnnotation("MaxLength", 20);

                    b.Property<DateTime>("DateDesignated");

                    b.Property<string>("LPCId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("LPNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("ObjectType")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("PhotoStatus");

                    b.Property<string>("PhotoURL")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Street");

                    b.Property<string>("Style")
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");

                    b.ToTable("LPCReport");
                });
        }
    }
}
