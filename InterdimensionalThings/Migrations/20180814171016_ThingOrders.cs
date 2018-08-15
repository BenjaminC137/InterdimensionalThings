using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class ThingOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_ThingCategory_ThingCategoryName",
                table: "Things");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThingCategory",
                table: "ThingCategory");

            migrationBuilder.RenameTable(
                name: "ThingCategory",
                newName: "ThingCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThingCategories",
                table: "ThingCategories",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "ThingsOrders",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingsOrders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThingsOrderThings",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: true),
                    ThingOrderID = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductID = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingsOrderThings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThingsOrderThings_ThingsOrders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "ThingsOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThingsOrderThings_OrderID",
                table: "ThingsOrderThings",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_ThingCategories_ThingCategoryName",
                table: "Things",
                column: "ThingCategoryName",
                principalTable: "ThingCategories",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_ThingCategories_ThingCategoryName",
                table: "Things");

            migrationBuilder.DropTable(
                name: "ThingsOrderThings");

            migrationBuilder.DropTable(
                name: "ThingsOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ThingCategories",
                table: "ThingCategories");

            migrationBuilder.RenameTable(
                name: "ThingCategories",
                newName: "ThingCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThingCategory",
                table: "ThingCategory",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_ThingCategory_ThingCategoryName",
                table: "Things",
                column: "ThingCategoryName",
                principalTable: "ThingCategory",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
