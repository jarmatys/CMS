using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class fixintegrationmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacbookPixel",
                table: "IntegrationSettings");

            migrationBuilder.AddColumn<string>(
                name: "FacebookPixel",
                table: "IntegrationSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacebookPixel",
                table: "IntegrationSettings");

            migrationBuilder.AddColumn<string>(
                name: "FacbookPixel",
                table: "IntegrationSettings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
