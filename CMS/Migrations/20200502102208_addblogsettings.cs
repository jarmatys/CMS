using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addblogsettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowComments",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "CommentsNotify",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "DateFormat",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "PostPerPage",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "TimeFormat",
                table: "Options");

            migrationBuilder.CreateTable(
                name: "BlogSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommentsNotify = table.Column<bool>(nullable: false),
                    PostPerPage = table.Column<int>(nullable: false),
                    AllowComments = table.Column<bool>(nullable: false),
                    DateFormat = table.Column<string>(nullable: true),
                    TimeFormat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogSettings");

            migrationBuilder.AddColumn<bool>(
                name: "AllowComments",
                table: "Options",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CommentsNotify",
                table: "Options",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DateFormat",
                table: "Options",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostPerPage",
                table: "Options",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TimeFormat",
                table: "Options",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
