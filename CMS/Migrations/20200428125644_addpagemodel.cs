using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addpagemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cannonical",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "Pages");

            migrationBuilder.AddColumn<bool>(
                name: "IsCannonical",
                table: "Pages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Pages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsIndex",
                table: "Pages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsIndex",
                table: "Options",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCannonical",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsIndex",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "IsIndex",
                table: "Options");

            migrationBuilder.AddColumn<string>(
                name: "Cannonical",
                table: "Pages",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Index",
                table: "Pages",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
