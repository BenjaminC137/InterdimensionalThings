using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class DateCreatedMissing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_ThingCarts_ThingCartID",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_ThingCartID",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ThingCartID",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ThingCarts");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ThingCarts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastModified",
                table: "ThingCarts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ThingCarts");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "ThingCarts");

            migrationBuilder.AddColumn<int>(
                name: "ThingCartID",
                table: "Things",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ThingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Things_ThingCartID",
                table: "Things",
                column: "ThingCartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_ThingCarts_ThingCartID",
                table: "Things",
                column: "ThingCartID",
                principalTable: "ThingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
