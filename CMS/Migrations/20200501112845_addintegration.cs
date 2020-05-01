using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class addintegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntegrationSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tawkto = table.Column<string>(nullable: true),
                    GoogleAnalytics = table.Column<string>(nullable: true),
                    FacbookPixel = table.Column<string>(nullable: true),
                    YandexMetrica = table.Column<string>(nullable: true),
                    GoogleMaps = table.Column<string>(nullable: true),
                    Recaptcha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegrationSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegrationSettings");
        }
    }
}
