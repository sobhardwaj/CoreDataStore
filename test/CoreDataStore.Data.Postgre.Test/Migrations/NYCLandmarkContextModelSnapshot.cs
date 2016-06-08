using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreDataStore.Data.Postgre;

namespace CoreDataStore.Data.Postgre.Test.Migrations
{
    [DbContext(typeof(NYCLandmarkContext))]
    partial class NYCLandmarkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("BOUNDARIES");

                    b.Property<string>("BoroughID");

                    b.Property<string>("CALEN_DATE");

                    b.Property<bool>("COUNT_BLDG");

                    b.Property<string>("DESIG_ADDR");

                    b.Property<string>("DESIG_DATE");

                    b.Property<string>("HIST_DISTR");

                    b.Property<string>("LAST_ACTIO");

                    b.Property<string>("LM_NAME");

                    b.Property<string>("LM_TYPE");

                    b.Property<int>("LOT");

                    b.Property<string>("LP_NUMBER");

                    b.Property<bool>("MOST_CURRE");

                    b.Property<string>("NON_BLDG");

                    b.Property<string>("OTHER_HEAR");

                    b.Property<string>("PLUTO_ADDR");

                    b.Property<string>("PUBLIC_HEA");

                    b.Property<bool>("SECND_BLDG");

                    b.Property<string>("STATUS");

                    b.Property<string>("STATUS_NOT");

                    b.Property<bool>("VACANT_LOT");

                    b.HasKey("Id");

                    b.ToTable("Landmark");
                });

            modelBuilder.Entity("CoreDataStore.Domain.Entities.LPCReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Architect");

                    b.Property<string>("Borough");

                    b.Property<DateTime>("DateDesignated");

                    b.Property<string>("LPCId");

                    b.Property<string>("LPNumber");

                    b.Property<string>("Name");

                    b.Property<string>("ObjectType");

                    b.Property<bool>("PhotoStatus");

                    b.Property<string>("PhotoURL");

                    b.Property<string>("Street");

                    b.Property<string>("Style");

                    b.HasKey("Id");

                    b.ToTable("LPCReport");
                });
        }
    }
}
