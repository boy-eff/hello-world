using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelloWorld.Infrastructure.Data.Migrations
{
    public partial class AddQueryFilterToWordEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Words",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Words");
        }
    }
}
