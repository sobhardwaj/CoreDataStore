using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Borough",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Architect",
                table: "LPCReport",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ObjectType",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LPCReport",
                nullable: true);

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
