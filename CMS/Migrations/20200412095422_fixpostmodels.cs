using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class fixpostmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Posts_PostModelId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostModelId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PostModelId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostModelId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostModelId",
                table: "Posts",
                column: "PostModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Posts_PostModelId",
                table: "Posts",
                column: "PostModelId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
