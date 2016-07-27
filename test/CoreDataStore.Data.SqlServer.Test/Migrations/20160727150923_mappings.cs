using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreDataStore.Data.SqlServer.Test.Migrations
{
    public partial class mappings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_LPCReport_LPNumber",
                table: "LPCReport",
                column: "LPNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Landmark_LP_NUMBER",
                table: "Landmark",
                column: "LP_NUMBER");

            migrationBuilder.AddForeignKey(
                name: "FK_Landmark_LPCReport",
                table: "Landmark",
                column: "LP_NUMBER",
                principalTable: "LPCReport",
                principalColumn: "LPNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landmark_LPCReport",
                table: "Landmark");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_LPCReport_LPNumber",
                table: "LPCReport");

            migrationBuilder.DropIndex(
                name: "IX_Landmark_LP_NUMBER",
                table: "Landmark");
        }
    }
}
