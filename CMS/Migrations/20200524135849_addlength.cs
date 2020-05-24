using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Length",
                table: "Medias",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Medias");
        }
    }
}
