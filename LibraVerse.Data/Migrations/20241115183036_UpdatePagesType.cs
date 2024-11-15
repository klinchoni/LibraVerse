using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePagesType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0c9bc1a1-c65e-451e-92ca-8b4b3c82cef7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1c82a17a-b8fb-40d7-8ea1-08ce6cbd9e5d"));

            migrationBuilder.AlterColumn<int>(
                name: "Pages",
                table: "Books",
                type: "int",
                maxLength: 21000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Pages", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("ce9fc1dc-96aa-4c4a-af39-ab0a90c6c3d0"), "Кристи Голдън", "Лорд на клановете разказва историята за възхода на вожд Трал към славата след краха на Ордата. Това е адаптация на отменената игра на Blizzard Warcraft Adventures: Lord of the Clans. Препубликуван е през 2016 г. за поредицата Blizzard Legends.", "Фентъзи", 278, new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лорд на клановете" },
                    { new Guid("ced3dc80-cbb2-48c0-b1a9-9386d6c791ab"), "Ангел Каралийчев", "Сборникът от 1942 г. „Българчета“ ни въвежда в магическия свят на Каралийчев. Част от поместените истории се развиват във вълшебни и приказни страни, докато други са поучителни разкази от неговото съвремие.\r\n\r\nСъчетанието от мъдростта на народните притчи и художествения талант на автора правят книгата четиво, което няма как да не бъде харесано от малките читатели.\r\n\r\nЗащото без значение в каква епоха живеем, децата си остават деца, а основните морални ценности са непреходни.", "Разкази и приказки за деца", 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1942), "Българчета" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ce9fc1dc-96aa-4c4a-af39-ab0a90c6c3d0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ced3dc80-cbb2-48c0-b1a9-9386d6c791ab"));

            migrationBuilder.AlterColumn<string>(
                name: "Pages",
                table: "Books",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 21000);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Genre", "Pages", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("0c9bc1a1-c65e-451e-92ca-8b4b3c82cef7"), "Ангел Каралийчев", "Сборникът от 1942 г. „Българчета“ ни въвежда в магическия свят на Каралийчев. Част от поместените истории се развиват във вълшебни и приказни страни, докато други са поучителни разкази от неговото съвремие.\r\n\r\nСъчетанието от мъдростта на народните притчи и художествения талант на автора правят книгата четиво, което няма как да не бъде харесано от малките читатели.\r\n\r\nЗащото без значение в каква епоха живеем, децата си остават деца, а основните морални ценности са непреходни.", "Разкази и приказки за деца", "192", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1942), "Българчета" },
                    { new Guid("1c82a17a-b8fb-40d7-8ea1-08ce6cbd9e5d"), "Кристи Голдън", "Лорд на клановете разказва историята за възхода на вожд Трал към славата след краха на Ордата. Това е адаптация на отменената игра на Blizzard Warcraft Adventures: Lord of the Clans. Препубликуван е през 2016 г. за поредицата Blizzard Legends.", "Фентъзи", "278", new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Лорд на клановете" }
                });
        }
    }
}
