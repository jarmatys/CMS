using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addcustomscripts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomScripts",
                table: "IntegrationSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomScripts",
                table: "IntegrationSettings");
        }
    }
}
