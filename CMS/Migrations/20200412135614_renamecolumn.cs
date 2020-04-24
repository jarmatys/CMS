using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class renamecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Posts_PostId",
                table: "Taxonomies");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Excerpt = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    CommentStatus = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    FullUrl = table.Column<string>(nullable: true),
                    MenuOrder = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Articles_PostId",
                table: "Taxonomies",
                column: "PostId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxonomies_Articles_PostId",
                table: "Taxonomies");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    CommentStatus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Content = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Excerpt = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    FullUrl = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    MenuOrder = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Slug = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Status = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxonomies_Posts_PostId",
                table: "Taxonomies",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
