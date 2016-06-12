using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PLUTO_ADDR",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OTHER_HEAR",
                table: "Landmark",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PLUTO_ADDR",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OTHER_HEAR",
                table: "Landmark",
                nullable: true);
        }
    }
}
