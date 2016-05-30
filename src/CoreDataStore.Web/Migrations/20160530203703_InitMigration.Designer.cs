using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreDataStore.Data.Sqlite;

namespace CoreDataStore.Web.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20160530203703_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901");

            modelBuilder.Entity("CoreDataStore.Domain.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Url")
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });
        }
    }
}
