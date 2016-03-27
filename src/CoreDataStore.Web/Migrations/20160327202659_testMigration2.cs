using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace CoreDataStore.Web.Migrations
{
    public partial class testMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "DataEventRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "ShortName", table: "DataEventRecord");
        }
    }
}
