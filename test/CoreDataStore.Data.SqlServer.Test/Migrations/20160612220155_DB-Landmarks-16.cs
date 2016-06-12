using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DESIG_ADDR",
                table: "Landmark",
                nullable: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CALEN_DATE",
                table: "Landmark",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DESIG_ADDR",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CALEN_DATE",
                table: "Landmark",
                nullable: true);
        }
    }
}
