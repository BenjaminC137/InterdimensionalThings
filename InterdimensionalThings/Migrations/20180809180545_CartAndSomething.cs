using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class CartAndSomething : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserID",
                table: "ThingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThingCartID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ThingCarts_ApplicationUserID",
                table: "ThingCarts",
                column: "ApplicationUserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThingCarts_AspNetUsers_ApplicationUserID",
                table: "ThingCarts",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThingCarts_AspNetUsers_ApplicationUserID",
                table: "ThingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ThingCarts_ApplicationUserID",
                table: "ThingCarts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserID",
                table: "ThingCarts");

            migrationBuilder.DropColumn(
                name: "ThingCartID",
                table: "AspNetUsers");
        }
    }
}
