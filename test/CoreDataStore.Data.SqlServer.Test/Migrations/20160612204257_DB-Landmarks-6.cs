using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "STATUS_NOT",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PUBLIC_HEA",
                table: "Landmark",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "STATUS_NOT",
                table: "Landmark",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PUBLIC_HEA",
                table: "Landmark",
                nullable: true);
        }
    }
}
