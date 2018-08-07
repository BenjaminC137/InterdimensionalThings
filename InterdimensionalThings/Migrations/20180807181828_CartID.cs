using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class CartID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ThingCartID",
                table: "Things",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ThingCarts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingCarts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ThingCartThings",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ThingCartID = table.Column<int>(nullable: false),
                    ThingID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateLastModified = table.Column<DateTime>(nullable: true),
                    ThingCartThingID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingCartThings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ThingCartThings_ThingCarts_ThingCartID",
                        column: x => x.ThingCartID,
                        principalTable: "ThingCarts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThingCartThings_ThingCartThings_ThingCartThingID",
                        column: x => x.ThingCartThingID,
                        principalTable: "ThingCartThings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ThingCartThings_Things_ThingID",
                        column: x => x.ThingID,
                        principalTable: "Things",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Things_ThingCartID",
                table: "Things",
                column: "ThingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_ThingCartThings_ThingCartID",
                table: "ThingCartThings",
                column: "ThingCartID");

            migrationBuilder.CreateIndex(
                name: "IX_ThingCartThings_ThingCartThingID",
                table: "ThingCartThings",
                column: "ThingCartThingID");

            migrationBuilder.CreateIndex(
                name: "IX_ThingCartThings_ThingID",
                table: "ThingCartThings",
                column: "ThingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_ThingCarts_ThingCartID",
                table: "Things",
                column: "ThingCartID",
                principalTable: "ThingCarts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_ThingCarts_ThingCartID",
                table: "Things");

            migrationBuilder.DropTable(
                name: "ThingCartThings");

            migrationBuilder.DropTable(
                name: "ThingCarts");

            migrationBuilder.DropIndex(
                name: "IX_Things_ThingCartID",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ThingCartID",
                table: "Things");
        }
    }
}
