using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("a0f8342a-ba3f-4fb2-a64b-a32e72446172"), "Angel Karaliichev", "The collection from 1942, Bulgarcheta introduces us to the magical world of Karaliychev. Some of the stories included are set in magical and fairy-tale lands, while others are instructive tales from his time. The combination of the wisdom of folk proverbs and the author's artistic talent make the book a read that will not fail to be enjoyed by young readers.", "Fairy tales", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1942), "Bulgarcheta" },
                    { new Guid("fa0735ec-5fce-47a4-bd3b-2bd353a8115c"), "Christie Golden", "Lord of the Clans is a novel by Christie Golden telling the story of Warchief Thrall's rise to glory after the collapse of the Horde. It is an adaptation of the cancelled Blizzard game Warcraft Adventures: Lord of the Clans. It was republished in 2016 for the Blizzard Legends series.", "Fantasy", new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Clans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
