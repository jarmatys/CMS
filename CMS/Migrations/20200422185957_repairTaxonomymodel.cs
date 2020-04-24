using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class repairTaxonomymodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Categories_CategoryId",
                table: "Taxonomies");

            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Tags_TagId",
                table: "Taxonomies");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Taxonomies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Taxonomies",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Categories_CategoryId",
                table: "Taxonomies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Tags_TagId",
                table: "Taxonomies",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Categories_CategoryId",
                table: "Taxonomies");

            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Tags_TagId",
                table: "Taxonomies");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "Taxonomies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Taxonomies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Categories_CategoryId",
                table: "Taxonomies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Tags_TagId",
                table: "Taxonomies",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
