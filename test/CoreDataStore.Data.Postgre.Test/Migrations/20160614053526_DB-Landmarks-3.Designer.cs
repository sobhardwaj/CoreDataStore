using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreDataStore.Data.Postgre;

namespace CoreDataStore.Data.Postgre.Test.Migrations
{
    [DbContext(typeof(NYCLandmarkContext))]
    [Migration("20160614053526_DB-Landmarks-3")]
    partial class DBLandmarks3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901");

            modelBuilder.Entity("CoreDataStore.Domain.Entities.Landmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("BBL");

                    b.Property<long>("BIN_NUMBER");

                    b.Property<int>("BLOCK");

                    b.Property<string>("BOUNDARIES")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("BoroughID")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 2);

                    b.Property<DateTime?>("CALEN_DATE");

                    b.Property<bool>("COUNT_BLDG");

                    b.Property<string>("DESIG_ADDR")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<DateTime?>("DESIG_DATE");

                    b.Property<string>("HIST_DISTR")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("LAST_ACTIO")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LM_NAME")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("LM_TYPE")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 19);

                    b.Property<int>("LOT");

                    b.Property<string>("LP_NUMBER")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<bool>("MOST_CURRE");

                    b.Property<string>("NON_BLDG")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("OTHER_HEAR")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("PLUTO_ADDR")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("PUBLIC_HEA")
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<bool>("SECND_BLDG");

                    b.Property<string>("STATUS")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("STATUS_NOT")
                        .HasColumnType("varchar")
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

                    b.Property<DateTime>("DateDesignated")
                        .HasColumnType("NpgsqlDate");

                    b.Property<string>("LPCId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("LPNumber")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Name");

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
