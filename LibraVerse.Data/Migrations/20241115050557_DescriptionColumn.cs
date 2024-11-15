using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4a0ad254-4810-4233-9f3a-53aaa1a10277"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4b268b42-dc5a-4e7e-96b7-aaa11cfa6e41"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Pages", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0c9bc1a1-c65e-451e-92ca-8b4b3c82cef7"), "Ангел Каралийчев", "Сборникът от 1942 г. „Българчета“ ни въвежда в магическия свят на Каралийчев. Част от поместените истории се развиват във вълшебни и приказни страни, докато други са поучителни разкази от неговото съвремие.\r\n\r\nСъчетанието от мъдростта на народните притчи и художествения талант на автора правят книгата четиво, което няма как да не бъде харесано от малките читатели.\r\n\r\nЗащото без значение в каква епоха живеем, децата си остават деца, а основните морални ценности са непреходни.", "Разкази и приказки за деца", "192", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1942), "Българчета" },
                    { new Guid("1c82a17a-b8fb-40d7-8ea1-08ce6cbd9e5d"), "Кристи Голдън", "Лорд на клановете разказва историята за възхода на вожд Трал към славата след краха на Ордата. Това е адаптация на отменената игра на Blizzard Warcraft Adventures: Lord of the Clans. Препубликуван е през 2016 г. за поредицата Blizzard Legends.", "Фентъзи", "278", new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лорд на клановете" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0c9bc1a1-c65e-451e-92ca-8b4b3c82cef7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1c82a17a-b8fb-40d7-8ea1-08ce6cbd9e5d"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Genre", "Pages", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("4a0ad254-4810-4233-9f3a-53aaa1a10277"), "Ангел Каралийчев", "Разкази и приказки за деца", "192", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1942), "Българчета" },
                    { new Guid("4b268b42-dc5a-4e7e-96b7-aaa11cfa6e41"), "Кристи Голдън", "Фентъзи", "278", new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лорд на клановете" }
                });
        }
    }
}
