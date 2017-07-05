using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreDataStore.Data.Postgre.EF.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LPCLamppost",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Block = table.Column<int>(nullable: true),
                    Borough = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Located = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Lot = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    SubType = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "varchar", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCLamppost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LPCLocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(nullable: true),
                    BBL = table.Column<long>(nullable: true),
                    Block = table.Column<int>(nullable: true),
                    Borough = table.Column<string>(type: "varchar", maxLength: 13, nullable: true),
                    LPNumber = table.Column<string>(type: "varchar", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Lot = table.Column<int>(nullable: true),
                    Name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    Neighborhood = table.Column<string>(nullable: true),
                    ObjectType = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(type: "varchar", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LPCReport",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Architect = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    Borough = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    DateDesignated = table.Column<DateTime>(nullable: false),
                    LPCId = table.Column<string>(type: "varchar", maxLength: 10, nullable: false),
                    LPCLocationId = table.Column<long>(nullable: true),
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
                    table.UniqueConstraint("AK_LPCReport_LPNumber", x => x.LPNumber);
                    table.ForeignKey(
                        name: "FK_LPCReport_LPCLocation_LPCLocationId",
                        column: x => x.LPCLocationId,
                        principalTable: "LPCLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Landmark",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BBL = table.Column<long>(nullable: false),
                    BIN_NUMBER = table.Column<long>(nullable: false),
                    BLOCK = table.Column<int>(nullable: false),
                    BOUNDARIES = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    BoroughID = table.Column<string>(type: "varchar", maxLength: 2, nullable: false),
                    CALEN_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    COUNT_BLDG = table.Column<bool>(nullable: false),
                    DESIG_ADDR = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    DESIG_DATE = table.Column<DateTime>(type: "date", nullable: true),
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
                    table.UniqueConstraint("AK_Landmark_BBL", x => x.BBL);
                    table.ForeignKey(
                        name: "FK_Landmark_LPCReport_LP_NUMBER",
                        column: x => x.LP_NUMBER,
                        principalTable: "LPCReport",
                        principalColumn: "LPNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PLUTO",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Address = table.Column<string>(maxLength: 28, nullable: true),
                    BBL = table.Column<long>(nullable: false),
                    Block = table.Column<int>(nullable: false),
                    Borough = table.Column<string>(nullable: true),
                    HistDist = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Lot = table.Column<int>(nullable: false),
                    LotArea = table.Column<int>(nullable: false),
                    NumBldgs = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(nullable: true),
                    XCoord = table.Column<int>(nullable: false),
                    YCoord = table.Column<int>(nullable: false),
                    YearBuilt = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLUTO", x => x.id);
                    table.ForeignKey(
                        name: "FK_PLUTO_Landmark_BBL",
                        column: x => x.BBL,
                        principalTable: "Landmark",
                        principalColumn: "BBL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Landmark_LP_NUMBER",
                table: "Landmark",
                column: "LP_NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_LPCReport_LPCLocationId",
                table: "LPCReport",
                column: "LPCLocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PLUTO_BBL",
                table: "PLUTO",
                column: "BBL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LPCLamppost");

            migrationBuilder.DropTable(
                name: "PLUTO");

            migrationBuilder.DropTable(
                name: "Landmark");

            migrationBuilder.DropTable(
                name: "LPCReport");

            migrationBuilder.DropTable(
                name: "LPCLocation");
        }
    }
}
