using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "BoroughID",
                table: "Landmark",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "BOUNDARIES",
                table: "Landmark",
                nullable: false);
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
                name: "BoroughID",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BOUNDARIES",
                table: "Landmark",
                nullable: true);
        }
    }
}
