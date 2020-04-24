using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class fixmediamodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Articles_ArticleId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_ArticleId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Articles");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Medias_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Medias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Medias_ImageId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ImageId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_ArticleId",
                table: "Medias",
                column: "ArticleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Articles_ArticleId",
                table: "Medias",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
