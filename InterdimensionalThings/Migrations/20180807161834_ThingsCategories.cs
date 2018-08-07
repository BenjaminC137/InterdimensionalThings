using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class ThingsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThingCategoryName",
                table: "Things",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Things_ThingCategoryName",
                table: "Things",
                column: "ThingCategoryName");

            migrationBuilder.AddForeignKey(
                name: "FK_Things_ThingCategory_ThingCategoryName",
                table: "Things",
                column: "ThingCategoryName",
                principalTable: "ThingCategory",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Things_ThingCategory_ThingCategoryName",
                table: "Things");

            migrationBuilder.DropIndex(
                name: "IX_Things_ThingCategoryName",
                table: "Things");

            migrationBuilder.DropColumn(
                name: "ThingCategoryName",
                table: "Things");
        }
    }
}
