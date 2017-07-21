using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreDataStore.Data.SqlServer.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColumnName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImportType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LPCLamppost",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Block = table.Column<int>(type: "int", nullable: true),
                    Borough = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Located = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Lot = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    SubType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCLamppost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LPCReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Architect = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Borough = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateDesignated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LPCId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LPNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ObjectType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhotoStatus = table.Column<bool>(type: "bit", nullable: false),
                    PhotoURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Style = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCReport", x => x.Id);
                    table.UniqueConstraint("AK_LPCReport_LPNumber", x => x.LPNumber);
                });

            migrationBuilder.CreateTable(
                name: "Pluto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BBL = table.Column<long>(type: "bigint", nullable: false),
                    Block = table.Column<int>(type: "int", nullable: false),
                    Borough = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    HistDist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Lot = table.Column<int>(type: "int", nullable: false),
                    LotArea = table.Column<int>(type: "int", nullable: false),
                    NumBldgs = table.Column<int>(type: "int", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: true),
                    XCoord = table.Column<int>(type: "int", nullable: false),
                    YCoord = table.Column<int>(type: "int", nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pluto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Landmark",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BBL = table.Column<long>(type: "bigint", nullable: false),
                    BIN_NUMBER = table.Column<long>(type: "bigint", nullable: false),
                    BLOCK = table.Column<int>(type: "int", nullable: false),
                    BOUNDARIES = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BoroughID = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CALEN_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COUNT_BLDG = table.Column<bool>(type: "bit", nullable: false),
                    DESIG_ADDR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DESIG_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HIST_DISTR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LAST_ACTIO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LM_NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LM_TYPE = table.Column<string>(type: "nvarchar(19)", maxLength: 19, nullable: true),
                    LOT = table.Column<int>(type: "int", nullable: false),
                    LP_NUMBER = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    MOST_CURRE = table.Column<bool>(type: "bit", nullable: false),
                    NON_BLDG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OBJECTID = table.Column<long>(type: "bigint", nullable: true),
                    OTHER_HEAR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PLUTO_ADDR = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PUBLIC_HEA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SECND_BLDG = table.Column<bool>(type: "bit", nullable: false),
                    STATUS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    STATUS_NOT = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    VACANT_LOT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landmark_LPCReport_LP_NUMBER",
                        column: x => x.LP_NUMBER,
                        principalTable: "LPCReport",
                        principalColumn: "LPNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LPCLocation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BBL = table.Column<long>(type: "bigint", nullable: true),
                    BIN = table.Column<long>(type: "bigint", nullable: true),
                    Block = table.Column<int>(type: "int", nullable: true),
                    Borough = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    LPNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    LocationType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Lot = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ObjectId = table.Column<long>(type: "bigint", nullable: true),
                    ObjectType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LPCLocation_LPCReport_LPNumber",
                        column: x => x.LPNumber,
                        principalTable: "LPCReport",
                        principalColumn: "LPNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Landmark_LP_NUMBER",
                table: "Landmark",
                column: "LP_NUMBER");

            migrationBuilder.CreateIndex(
                name: "IX_LPCLocation_LPNumber",
                table: "LPCLocation",
                column: "LPNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "Landmark");

            migrationBuilder.DropTable(
                name: "LPCLamppost");

            migrationBuilder.DropTable(
                name: "LPCLocation");

            migrationBuilder.DropTable(
                name: "Pluto");

            migrationBuilder.DropTable(
                name: "LPCReport");
        }
    }
}
