using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DESIG_DATE",
                table: "Landmark",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DESIG_DATE",
                table: "Landmark",
                nullable: true);
        }
    }
}
