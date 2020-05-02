using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class updatesheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailPort",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "MailServerLogin",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "MailServerPassword",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "MailServerUrl",
                table: "Options");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MailPort",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MailServerLogin",
                table: "Options",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailServerPassword",
                table: "Options",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MailServerUrl",
                table: "Options",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
