using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForNoImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/assets/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/assets/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/assets/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/assets/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/assets/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8eb412-65a9-4050-8c67-62278f3af93c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2744037d-78f2-4cd3-97e4-adfdac0378a3", "AQAAAAIAAYagAAAAEGxuZEyv251x+kUEyeoZzF7ZX3DDd21vb9ToXC6dKSDIHBvV2nsWkVMTk9bsSPxNkQ==", "37f626b0-b563-4a85-9b6c-a60a63232bd5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8482124a-1681-41b9-81bd-83e20223d345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ac423a-8338-4fa9-a345-1b8f392a3a7e", "AQAAAAIAAYagAAAAEO1dkwENR8oxTxasDhtDa+7EY6oiOpWOBOc69/7xQHVjgjGinPvB1ED3Ft/SueEPJw==", "88513415-780d-41b4-af09-99d090a5dddf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9abf1366-cadf-4837-bc30-1b77599ff9cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24951978-0dea-4c66-bc66-2f595c537a10", "AQAAAAIAAYagAAAAEEcPM3je7SGl03xKE3NDT5jaKXB384Tq4Su27aIzrVwV8nB/JIEsr01JvNshDQpBDg==", "bf9e65c6-7c52-49cf-8d4d-7ec79e1e176f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4a1311e-dff4-4c3a-9cf7-b794557bdf80",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc0d3e96-8367-4870-a6a0-28d058d8e785", "AQAAAAIAAYagAAAAEGDiZs6eZAL0N6hob+7xUZESdZHBW5YQiyq12g8OQ0xnpYlM8fXpWM6ewgz8Y4YT8g==", "1fbb28da-1b66-4803-8025-1eab880ad84a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4fbe2f71-126f-46c3-af99-8dc035eac772",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85876143-211a-463a-bf54-739ecb43981b", "AQAAAAIAAYagAAAAEDks0acolPor5TBfNsWSbDWju29aCqNrmNrW44r6wN/qnLQlpp7fzXFFuETODnPHzg==", "6b99fe62-997c-48c1-b7e2-21bd619a74dd" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/assets/img/coming-soon.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "/img/coming-soon.jpg");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/img/coming-soon.jpg");

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

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "/img/coming-soon.jpg");
        }
    }
}
