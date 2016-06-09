using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LPCReport",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LPNumber",
                table: "LPCReport",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LPNumber",
                table: "LPCReport",
                nullable: true);
        }
    }
}
