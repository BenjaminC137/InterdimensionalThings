using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class shippingoptinorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingOption",
                table: "ThingsOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingOption",
                table: "ThingsOrders");
        }
    }
}
