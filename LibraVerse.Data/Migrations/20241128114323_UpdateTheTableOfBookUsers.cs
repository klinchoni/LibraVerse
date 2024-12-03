using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTheTableOfBookUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersCurrentlyReading");

            migrationBuilder.DropTable(
                name: "UsersWantToRead");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksUsersRead",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The current User's Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The Identifier of the User");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BooksUsersRead",
                type: "int",
                nullable: false,
                comment: "The current Book's Identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The Identifier of the Book");

            migrationBuilder.CreateTable(
                name: "BooksUsersCurrentlyReading",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier"),
                    CurrentPage = table.Column<int>(type: "int", nullable: false, comment: "The Page the User is on to"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time when the entity was added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksUsersCurrentlyReading", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BooksUsersCurrentlyReading_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksUsersCurrentlyReading_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksUsersWantToRead",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The current Book's Identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The current User's Identifier"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time when the entity was added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksUsersWantToRead", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BooksUsersWantToRead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksUsersWantToRead_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8eb412-65a9-4050-8c67-62278f3af93c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab267007-a340-4bea-81b1-6c8ed8a986a8", "AQAAAAIAAYagAAAAECUE5ciVp2uJgTwOrNA8iw644ZPZ8zQwuoGnPVM0aboOA9S9VGxsRdiD4zK23gnJZg==", "dde0fc1a-8951-4fb8-9af9-e8c40d05ff32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8482124a-1681-41b9-81bd-83e20223d345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d8cd66e-8c18-4981-be0d-16715b51a1b6", "AQAAAAIAAYagAAAAEDpUq/MF/TOFUmptajB7MuzvGslK3dJO8MTvSx5nvmSP06tyUiBncSwG50Dtszxelw==", "b81aafd1-8f8b-427d-acc7-4b9ed2655b6b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9abf1366-cadf-4837-bc30-1b77599ff9cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "28c88d80-5ab4-4057-b612-df6bb9c8b88f", "AQAAAAIAAYagAAAAEMtgPTu7y7DQbeyyemtkFbQOnUIMJ65bhN0cmaEtGHSzPMd5/jiIaw/NLdpsTRZm0A==", "37f137eb-5e1a-47a1-90c1-ef94c70f2911" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4a1311e-dff4-4c3a-9cf7-b794557bdf80",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2d16ffd-0b85-49ed-b708-21547601427a", "AQAAAAIAAYagAAAAEFFhqpUkxrugMA9kjp1YIUWSF0BP0OT7CjGnj9qzIz9KdH2OFGc5l4DmQZmrJIfkbQ==", "dc8284f1-1ec9-43ab-8f6c-43f61d28c97a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4fbe2f71-126f-46c3-af99-8dc035eac772",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "90da7a7b-12b1-4bc6-b0f8-13a9d7c13f86", "AQAAAAIAAYagAAAAED0M1skkz1vaVDTmpIAYvgDyh4qhxCCgXcecGZV6rlhKCjyi07nBgpUKcy/6twbLKA==", "1a2f4273-0fec-4de2-98b2-cc96b2c2ff0c" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, "9abf1366-cadf-4837-bc30-1b77599ff9cb" },
                    { 2, "8482124a-1681-41b9-81bd-83e20223d345" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksUsersCurrentlyReading_UserId",
                table: "BooksUsersCurrentlyReading",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksUsersWantToRead_UserId",
                table: "BooksUsersWantToRead",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksUsersCurrentlyReading");

            migrationBuilder.DropTable(
                name: "BooksUsersWantToRead");

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "BooksUsersRead",
                type: "nvarchar(450)",
                nullable: false,
                comment: "The Identifier of the User",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "The current User's Identifier");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BooksUsersRead",
                type: "int",
                nullable: false,
                comment: "The Identifier of the Book",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The current Book's Identifier");

            migrationBuilder.CreateTable(
                name: "UsersCurrentlyReading",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The Identifier of the Book"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Identifier of the User"),
                    CurrentPage = table.Column<int>(type: "int", nullable: false, comment: "The Page the User is on to"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time when the entity was added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersCurrentlyReading", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersCurrentlyReading_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersCurrentlyReading_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersWantToRead",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false, comment: "The Identifier of the Book"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The Identifier of the User"),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The time when the entity was added")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersWantToRead", x => new { x.BookId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersWantToRead_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersWantToRead_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8eb412-65a9-4050-8c67-62278f3af93c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "004b4de3-fad1-401c-8436-f0a58f8c6668", "AQAAAAIAAYagAAAAENRLS9CuPFfq/TVfxPHVMjeNiBbFuOPyTkiRSTmChTQ+JScNw3YEnQX1rkEcf9DN5g==", "5a553126-0539-4978-9e16-913db0574990" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8482124a-1681-41b9-81bd-83e20223d345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ca1063f-f634-4826-87da-ac8bde5070b6", "AQAAAAIAAYagAAAAEBtqIwDsaClG0A9F0i4eYAuYjti7gZ/WcwJg7iKPC4vaS2hF9k72dNZUmLbfW7FjNQ==", "afe58646-f82b-42d7-8d1a-e91a8551dc33" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9abf1366-cadf-4837-bc30-1b77599ff9cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8e7f497-ad15-4a3c-959b-6975109ab953", "AQAAAAIAAYagAAAAEDfBCFT+bfqSc6NUbrinIenUYkwlRF14yjFalJhGJ0OcYDKh1aYx6iJcJWNnXNlHsw==", "a2dc3247-dd5b-4372-9058-cc9ae7a462e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4a1311e-dff4-4c3a-9cf7-b794557bdf80",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8faea654-150c-450e-b649-3421da7e2851", "AQAAAAIAAYagAAAAEDikhYy6XjcKCEy4ucrQhe3dQmztfUcfRsFtLRtFBiJi/VTXTY+Ypv0bzYGDHxwbMQ==", "f7f91a47-33dd-4ba2-9446-cc04f6d39293" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4fbe2f71-126f-46c3-af99-8dc035eac772",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8fc7614-6d85-4067-9165-b21b37684162", "AQAAAAIAAYagAAAAEFouWeaGHPjQsMUVUt3B0nN7ctwsjYdYUmOwn10FZo6DQrbLKah3WPTL+5TwFCpp9A==", "cb6f6daa-3c75-4b92-9243-711730840819" });

            migrationBuilder.CreateIndex(
                name: "IX_UsersCurrentlyReading_UserId",
                table: "UsersCurrentlyReading",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersWantToRead_UserId",
                table: "UsersWantToRead",
                column: "UserId");
        }
    }
}
