using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LP_NUMBER",
                table: "Landmark",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LP_NUMBER",
                table: "Landmark",
                nullable: true);
        }
    }
}
