using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloWorld.Infrastructure.Migrations
{
    public partial class EditCollectionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WordCollections",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "WordCollections",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "WordCollections");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "WordCollections");
        }
    }
}
