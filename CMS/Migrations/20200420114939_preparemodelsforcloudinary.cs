using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class preparemodelsforcloudinary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiniaturePath",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Medias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Medias");

            migrationBuilder.AddColumn<string>(
                name: "MiniaturePath",
                table: "Medias",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Medias",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
