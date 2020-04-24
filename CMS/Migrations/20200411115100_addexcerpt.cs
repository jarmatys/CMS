using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addexcerpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "Posts");
        }
    }
}
