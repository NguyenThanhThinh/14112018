using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _14112018.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    PublishedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Content", "IsPublished", "PublishedDate", "Title" },
                values: new object[] { 1, "Content 1", true, new DateTime(2018, 11, 14, 20, 24, 12, 179, DateTimeKind.Local), "Topic 1" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Content", "IsPublished", "PublishedDate", "Title" },
                values: new object[] { 2, "Content 2", true, new DateTime(2018, 11, 14, 20, 24, 12, 204, DateTimeKind.Local), "Topic 2" });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Content", "IsPublished", "PublishedDate", "Title" },
                values: new object[] { 3, "Content 3", false, new DateTime(2018, 11, 14, 20, 24, 12, 204, DateTimeKind.Local), "Topic 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
