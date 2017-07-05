﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreDataStore.Data.SqlServer.EF.Migrations
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Block = table.Column<int>(nullable: true),
                    Borough = table.Column<string>(maxLength: 20, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Located = table.Column<string>(maxLength: 100, nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Lot = table.Column<int>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    SubType = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCLamppost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LPCReport",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Architect = table.Column<string>(maxLength: 200, nullable: true),
                    Borough = table.Column<string>(maxLength: 20, nullable: true),
                    DateDesignated = table.Column<DateTime>(nullable: false),
                    LPCId = table.Column<string>(maxLength: 10, nullable: false),
                    LPNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    ObjectType = table.Column<string>(maxLength: 50, nullable: true),
                    PhotoStatus = table.Column<bool>(nullable: false),
                    PhotoURL = table.Column<string>(maxLength: 500, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Style = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPCReport", x => x.Id);
                    table.UniqueConstraint("AK_LPCReport_LPNumber", x => x.LPNumber);
                });

            migrationBuilder.CreateTable(
                name: "Landmark",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BBL = table.Column<long>(nullable: false),
                    BIN_NUMBER = table.Column<long>(nullable: false),
                    BLOCK = table.Column<int>(nullable: false),
                    BOUNDARIES = table.Column<string>(maxLength: 50, nullable: false),
                    BoroughID = table.Column<string>(maxLength: 2, nullable: false),
                    CALEN_DATE = table.Column<DateTime>(nullable: true),
                    COUNT_BLDG = table.Column<bool>(nullable: false),
                    DESIG_ADDR = table.Column<string>(maxLength: 200, nullable: true),
                    DESIG_DATE = table.Column<DateTime>(nullable: true),
                    HIST_DISTR = table.Column<string>(maxLength: 200, nullable: true),
                    LAST_ACTIO = table.Column<string>(maxLength: 50, nullable: true),
                    LM_NAME = table.Column<string>(maxLength: 200, nullable: true),
                    LM_TYPE = table.Column<string>(maxLength: 19, nullable: true),
                    LOT = table.Column<int>(nullable: false),
                    LP_NUMBER = table.Column<string>(maxLength: 10, nullable: true),
                    MOST_CURRE = table.Column<bool>(nullable: false),
                    NON_BLDG = table.Column<string>(maxLength: 100, nullable: true),
                    OTHER_HEAR = table.Column<string>(maxLength: 200, nullable: true),
                    PLUTO_ADDR = table.Column<string>(maxLength: 200, nullable: true),
                    PUBLIC_HEA = table.Column<string>(maxLength: 200, nullable: true),
                    SECND_BLDG = table.Column<bool>(nullable: false),
                    STATUS = table.Column<string>(maxLength: 50, nullable: false),
                    STATUS_NOT = table.Column<string>(maxLength: 200, nullable: true),
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
                name: "LPCLocation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    BBL = table.Column<long>(nullable: true),
                    Block = table.Column<int>(nullable: true),
                    Borough = table.Column<string>(maxLength: 13, nullable: true),
                    LPNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: true),
                    Lot = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Neighborhood = table.Column<string>(maxLength: 100, nullable: true),
                    ObjectType = table.Column<string>(maxLength: 50, nullable: false),
                    Street = table.Column<string>(maxLength: 255, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Pluto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    BBL = table.Column<long>(nullable: false),
                    Block = table.Column<int>(nullable: false),
                    Borough = table.Column<string>(maxLength: 2, nullable: false),
                    HistDist = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Lot = table.Column<int>(nullable: false),
                    LotArea = table.Column<int>(nullable: false),
                    NumBldgs = table.Column<int>(nullable: false),
                    OwnerName = table.Column<string>(maxLength: 21, nullable: true),
                    XCoord = table.Column<int>(nullable: false),
                    YCoord = table.Column<int>(nullable: false),
                    YearBuilt = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pluto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pluto_Landmark_BBL",
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
                name: "IX_LPCLocation_LPNumber",
                table: "LPCLocation",
                column: "LPNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pluto_BBL",
                table: "Pluto",
                column: "BBL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LPCLamppost");

            migrationBuilder.DropTable(
                name: "LPCLocation");

            migrationBuilder.DropTable(
                name: "Pluto");

            migrationBuilder.DropTable(
                name: "Landmark");

            migrationBuilder.DropTable(
                name: "LPCReport");
        }
    }
}
