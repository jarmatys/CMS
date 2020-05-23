using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addfooterandheaderscript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomScripts",
                table: "IntegrationSettings");

            migrationBuilder.AddColumn<string>(
                name: "CustomFooterScripts",
                table: "IntegrationSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomHeaderScripts",
                table: "IntegrationSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomFooterScripts",
                table: "IntegrationSettings");

            migrationBuilder.DropColumn(
                name: "CustomHeaderScripts",
                table: "IntegrationSettings");

            migrationBuilder.AddColumn<string>(
                name: "CustomScripts",
                table: "IntegrationSettings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
