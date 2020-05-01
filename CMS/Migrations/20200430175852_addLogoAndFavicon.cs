using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addLogoAndFavicon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaviconId",
                table: "Options",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoId",
                table: "Options",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Options_FaviconId",
                table: "Options",
                column: "FaviconId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_LogoId",
                table: "Options",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Medias_FaviconId",
                table: "Options",
                column: "FaviconId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Medias_LogoId",
                table: "Options",
                column: "LogoId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Options_Medias_FaviconId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Medias_LogoId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_FaviconId",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Options_LogoId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "FaviconId",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Options");
        }
    }
}
