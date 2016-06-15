using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.Postgre.Test.Migrations
{
    public partial class DBLandmarks4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "LPCReport",
                type: "varchar",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoURL",
                table: "LPCReport",
                type: "varchar",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                table: "LPCReport",
                type: "varchar",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LPNumber",
                table: "LPCReport",
                type: "varchar",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LPCId",
                table: "LPCReport",
                type: "varchar",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDesignated",
                table: "LPCReport",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Borough",
                table: "LPCReport",
                type: "varchar",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Architect",
                table: "LPCReport",
                type: "varchar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoURL",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LPNumber",
                table: "LPCReport",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LPCId",
                table: "LPCReport",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDesignated",
                table: "LPCReport",
                type: "NpgsqlDate",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Borough",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Architect",
                table: "LPCReport",
                nullable: true);
        }
    }
}
