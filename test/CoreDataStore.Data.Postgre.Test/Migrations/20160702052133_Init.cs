using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.Postgre.Test.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Landmark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    BBL = table.Column<long>(nullable: false),
                    BIN_NUMBER = table.Column<long>(nullable: false),
                    BLOCK = table.Column<int>(nullable: false),
                    BOUNDARIES = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    BoroughID = table.Column<string>(type: "varchar", maxLength: 2, nullable: false),
                    CALEN_DATE = table.Column<DateTime>(nullable: true),
                    COUNT_BLDG = table.Column<bool>(nullable: false),
                    DESIG_ADDR = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    DESIG_DATE = table.Column<DateTime>(nullable: true),
                    HIST_DISTR = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    LAST_ACTIO = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    LM_NAME = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    LM_TYPE = table.Column<string>(type: "varchar", maxLength: 19, nullable: true),
                    LOT = table.Column<int>(nullable: false),
                    LP_NUMBER = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    MOST_CURRE = table.Column<bool>(nullable: false),
                    NON_BLDG = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    OTHER_HEAR = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    PLUTO_ADDR = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    PUBLIC_HEA = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    SECND_BLDG = table.Column<bool>(nullable: false),
                    STATUS = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    STATUS_NOT = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    VACANT_LOT = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmark", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LPCReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    Architect = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    Borough = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    DateDesignated = table.Column<DateTime>(nullable: false),
                    LPCId = table.Column<string>(type: "varchar", maxLength: 10, nullable: false),
                    LPNumber = table.Column<string>(type: "varchar", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "varchar", nullable: false),
                    ObjectType = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    PhotoStatus = table.Column<bool>(nullable: false),
                    PhotoURL = table.Column<string>(type: "varchar", maxLength: 500, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Style = table.Column<string>(type: "varchar", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCReport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Landmark");

            migrationBuilder.DropTable(
                name: "LPCReport");
        }
    }
}
