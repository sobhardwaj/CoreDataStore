using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NON_BLDG",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LM_TYPE",
                table: "Landmark",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NON_BLDG",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LM_TYPE",
                table: "Landmark",
                nullable: true);
        }
    }
}
