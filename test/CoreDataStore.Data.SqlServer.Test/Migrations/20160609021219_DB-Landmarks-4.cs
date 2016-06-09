using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class DBLandmarks4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LPNumber",
                table: "LPCReport",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "LPCId",
                table: "LPCReport",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDesignated",
                table: "LPCReport",
                type: "datetime",
                nullable: false);
        }
    }
}
