using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class repairarticlemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Articles");

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Articles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Articles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Articles",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
