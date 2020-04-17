using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class mediatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Medias",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeMediaId",
                table: "Medias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MediaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TypeId",
                table: "Medias",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_MediaTypes_TypeId",
                table: "Medias",
                column: "TypeId",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_MediaTypes_TypeId",
                table: "Medias");

            migrationBuilder.DropTable(
                name: "MediaTypes");

            migrationBuilder.DropIndex(
                name: "IX_Medias_TypeId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TypeMediaId",
                table: "Medias");
        }
    }
}
