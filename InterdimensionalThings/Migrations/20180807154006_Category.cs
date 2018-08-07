using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InterdimensionalThings.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThingCategory",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "Now(6)"),
                    DateLastModified = table.Column<DateTime>(nullable: true, defaultValueSql: "Now(6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThingCategory", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThingCategory");
        }
    }
}
