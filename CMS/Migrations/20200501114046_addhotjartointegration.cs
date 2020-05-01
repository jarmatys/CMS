using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addhotjartointegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Hotjar",
                table: "IntegrationSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hotjar",
                table: "IntegrationSettings");
        }
    }
}
