using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class TimeStamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Things",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "Things",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Things");
        }
    }
}
