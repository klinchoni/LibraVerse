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
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
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
                    { new Guid("666e5832-1218-4f61-a2d0-47fd25bba604"), "Christie Golden", "Raised from infancy by cruel human masters who sought to mold him into their perfect pawn, Thrall was driven by both the savagery in his heart and the cunning of his upbringing to pursue a destiny he was only beginning to understand to break his bondage and rediscover the ancient traditions of his people.", "Fantasy", new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Clans" },
                    { new Guid("ad4f09cf-6117-416b-9920-d1e9009d270f"), "Angel Karaliichev", "The collection from 1942, Bulgarcheta introduces us to the magical world of Karaliychev. Some of the stories included are set in magical and fairy-tale lands, while others are instructive tales from his time. The combination of the wisdom of folk proverbs and the author's artistic talent make the book a read that will not fail to be enjoyed by young readers.", "Fairy tales", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1942), "Bulgarcheta" }
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
