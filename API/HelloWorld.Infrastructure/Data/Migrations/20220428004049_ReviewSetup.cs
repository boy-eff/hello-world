using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HelloWorld.Infrastructure.Migrations
{
    public partial class ReviewSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordCollectionReview");

            migrationBuilder.CreateTable(
                name: "WordCollectionReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WordCollectionId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ReviewTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCollectionReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordCollectionReviews_WordCollections_WordCollectionId",
                        column: x => x.WordCollectionId,
                        principalTable: "WordCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordCollectionReviews_WordCollectionId",
                table: "WordCollectionReviews",
                column: "WordCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordCollectionReviews");

            migrationBuilder.CreateTable(
                name: "WordCollectionReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WordCollectionId = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    ReviewTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordCollectionReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WordCollectionReview_WordCollections_WordCollectionId",
                        column: x => x.WordCollectionId,
                        principalTable: "WordCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordCollectionReview_WordCollectionId",
                table: "WordCollectionReview",
                column: "WordCollectionId");
        }
    }
}
