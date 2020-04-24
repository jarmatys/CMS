using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class renamearticlename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Articles_PostId",
                table: "Taxonomies");

            migrationBuilder.DropIndex(
                name: "IX_Taxonomies_PostId",
                table: "Taxonomies");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Taxonomies");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Taxonomies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomies_ArticleId",
                table: "Taxonomies",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Articles_ArticleId",
                table: "Taxonomies",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Articles_ArticleId",
                table: "Taxonomies");

            migrationBuilder.DropIndex(
                name: "IX_Taxonomies_ArticleId",
                table: "Taxonomies");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Taxonomies");

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Taxonomies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Taxonomies_PostId",
                table: "Taxonomies",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Articles_PostId",
                table: "Taxonomies",
                column: "PostId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
