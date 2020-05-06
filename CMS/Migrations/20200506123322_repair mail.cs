using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class repairmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "EmailSettings");

            migrationBuilder.AddColumn<string>(
                name: "EmailFrom",
                table: "EmailSettings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailTo",
                table: "EmailSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailFrom",
                table: "EmailSettings");

            migrationBuilder.DropColumn(
                name: "EmailTo",
                table: "EmailSettings");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "EmailSettings",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
