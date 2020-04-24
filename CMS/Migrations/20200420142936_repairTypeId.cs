using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class repairTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_MediaTypes_TypeId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TypeMediaId",
                table: "Medias");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Medias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_MediaTypes_TypeId",
                table: "Medias",
                column: "TypeId",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_MediaTypes_TypeId",
                table: "Medias");

            migrationBuilder.AlterColumn<int>(
                name: "TypeId",
                table: "Medias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TypeMediaId",
                table: "Medias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_MediaTypes_TypeId",
                table: "Medias",
                column: "TypeId",
                principalTable: "MediaTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
