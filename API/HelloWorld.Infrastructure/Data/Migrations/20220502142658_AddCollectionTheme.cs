using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HelloWorld.Infrastructure.Data.Migrations
{
    public partial class AddCollectionTheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "WordCollections");

            migrationBuilder.AddColumn<int>(
                name: "WordCollectionThemeId",
                table: "WordCollections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WordCollectionThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCollectionThemes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordCollections_WordCollectionThemeId",
                table: "WordCollections",
                column: "WordCollectionThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordCollections_WordCollectionThemes_WordCollectionThemeId",
                table: "WordCollections",
                column: "WordCollectionThemeId",
                principalTable: "WordCollectionThemes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordCollections_WordCollectionThemes_WordCollectionThemeId",
                table: "WordCollections");

            migrationBuilder.DropTable(
                name: "WordCollectionThemes");

            migrationBuilder.DropIndex(
                name: "IX_WordCollections_WordCollectionThemeId",
                table: "WordCollections");

            migrationBuilder.DropColumn(
                name: "WordCollectionThemeId",
                table: "WordCollections");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "WordCollections",
                type: "text",
                nullable: true);
        }
    }
}
