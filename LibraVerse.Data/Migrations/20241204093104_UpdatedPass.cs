using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8eb412-65a9-4050-8c67-62278f3af93c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "884ba5cd-c8ef-4ce0-b900-9681b53c048b", "AQAAAAIAAYagAAAAEJYE3sTDpeqSLtKIqiDUxPcuhSFXxb03+SRc5Ge9I2P4FrxWCtxyuH04dlbBqXOL0Q==", "61fca820-5e3e-499e-9d0e-72b55807878e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8482124a-1681-41b9-81bd-83e20223d345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ad83635-92f0-40c8-9e4e-ce216aaed729", "AQAAAAIAAYagAAAAEJnRKheKD+As0lX5vmvdSConstrCSRFopNcDbGmGI3P+0y9Ck32VcgTonanhDTP2Kg==", "5ca77efb-392b-4490-b721-07e4bb51f051" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9abf1366-cadf-4837-bc30-1b77599ff9cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "351a0c7c-47dc-4e26-8a0a-79a7b8e8b78a", "AQAAAAIAAYagAAAAEC8eYVUT665vIoRvjH6X/uLnK3mK2ojvnJT9c5poVtFe9UQ5Adafa7AsJQln0L+uGQ==", "f11c33b4-5c89-4ade-a191-e354276a8777" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4a1311e-dff4-4c3a-9cf7-b794557bdf80",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a1335dd-45b9-44a6-be94-5b9fbe5fa11c", "AQAAAAIAAYagAAAAEBVIt63jGQqTfdggURPgNOjO5ImV+gpeidb+hfyyySsgT0XRvnalIoM6ypHjd23pqg==", "fa4c942d-3af8-4a92-8821-12a0a08b3cb9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4fbe2f71-126f-46c3-af99-8dc035eac772",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a991ea8d-e3aa-4d2d-8220-1a742224199e", "AQAAAAIAAYagAAAAEDWOdMIuv/9UYaeRV5yPt6y4l095AM82Bm6WOsZyK/WRCI3c2puW4kI4Sj5PuTY7OA==", "80abcb2e-16ba-41ba-93ae-7b212d23d797" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 12, 4, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8eb412-65a9-4050-8c67-62278f3af93c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3584ddfe-adf0-4328-8149-4fb63e465899", "AQAAAAIAAYagAAAAEJJ7zprwXP8EObDangWa+imojzavrjbdfnGts/GdDkp9pFfj0Pj+PzPkNgDjpkNKcA==", "7f4df67f-9fc5-4804-a8f7-29fe0ba3e483" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8482124a-1681-41b9-81bd-83e20223d345",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ed487e0-8fee-4db5-9465-9a7a2c562c4d", "AQAAAAIAAYagAAAAEDg+oVgaoRT1q4brJ8xDfnI/jnUoHCHUEjHImoLErekQukbxWuyFm5LbLbNZr3rbfQ==", "4ab07def-4bcf-41ad-9d13-08cde9318f42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9abf1366-cadf-4837-bc30-1b77599ff9cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c393751e-8997-48a1-a325-32188af28241", "AQAAAAIAAYagAAAAEHHdrDF3/j3QsX+PBJ2446HKiYnyGOJTn9zBFpLM1vlcFRPeB3/U2IKErUYZ9S7KEg==", "a7f0115a-17de-460a-89e0-23c20cd0600b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4a1311e-dff4-4c3a-9cf7-b794557bdf80",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12b5f345-8b27-4126-8d64-84da47311909", "AQAAAAIAAYagAAAAEJ684+I6q4ey5dRJ3aOPDDicUgdZn0wRVXaaVxfFg/7BV2KbdVMgh2xkIUa73LVQQQ==", "5d6b7fb5-915f-4760-bec0-23e5410ba002" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4fbe2f71-126f-46c3-af99-8dc035eac772",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7e8c184-c391-4dc9-9b8b-3f8da015446e", "AQAAAAIAAYagAAAAEK2po/KE7sW1DsRnnROeMcJTqd5XnQ3iz16A2eBGufIFfUyzcv3ObWTkDBh11/6HBw==", "bd1d9098-d75e-4c47-8b9d-631ecb7be760" });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookStores",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ClosingTime", "OpeningTime" },
                values: new object[] { new DateTime(2024, 11, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
