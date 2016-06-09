using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BBL = table.Column<long>(nullable: false),
                    BIN_NUMBER = table.Column<long>(nullable: false),
                    BLOCK = table.Column<int>(nullable: false),
                    BOUNDARIES = table.Column<string>(nullable: true),
                    BoroughID = table.Column<string>(nullable: true),
                    CALEN_DATE = table.Column<string>(nullable: true),
                    COUNT_BLDG = table.Column<bool>(nullable: false),
                    DESIG_ADDR = table.Column<string>(nullable: true),
                    DESIG_DATE = table.Column<string>(nullable: true),
                    HIST_DISTR = table.Column<string>(nullable: true),
                    LAST_ACTIO = table.Column<string>(nullable: true),
                    LM_NAME = table.Column<string>(nullable: true),
                    LM_TYPE = table.Column<string>(nullable: true),
                    LOT = table.Column<int>(nullable: false),
                    LP_NUMBER = table.Column<string>(nullable: true),
                    MOST_CURRE = table.Column<bool>(nullable: false),
                    NON_BLDG = table.Column<string>(nullable: true),
                    OTHER_HEAR = table.Column<string>(nullable: true),
                    PLUTO_ADDR = table.Column<string>(nullable: true),
                    PUBLIC_HEA = table.Column<string>(nullable: true),
                    SECND_BLDG = table.Column<bool>(nullable: false),
                    STATUS = table.Column<string>(nullable: true),
                    STATUS_NOT = table.Column<string>(nullable: true),
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Architect = table.Column<string>(nullable: true),
                    Borough = table.Column<string>(nullable: true),
                    DateDesignated = table.Column<DateTime>(nullable: false),
                    LPCId = table.Column<string>(nullable: true),
                    LPNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ObjectType = table.Column<string>(nullable: true),
                    PhotoStatus = table.Column<bool>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true)
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
