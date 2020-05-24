using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class removeoptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdminEmail = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BlogDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BlogName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FaviconId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    IsIndex = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LogoId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    SiteUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserCanRegister = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Medias_FaviconId",
                        column: x => x.FaviconId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Options_Medias_LogoId",
                        column: x => x.LogoId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Options_FaviconId",
                table: "Options",
                column: "FaviconId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_LogoId",
                table: "Options",
                column: "LogoId");
        }
    }
}
