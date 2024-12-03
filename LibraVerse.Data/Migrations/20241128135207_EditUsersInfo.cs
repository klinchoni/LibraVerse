using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraVerse.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditUsersInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8eb412-65a9-4050-8c67-62278f3af93c",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "3584ddfe-adf0-4328-8149-4fb63e465899", "petya_guest@gmail.com", "PETYA_GUEST@GMAIL.COM", "PETYA_GUEST@GMAIL.COM", "AQAAAAIAAYagAAAAEJJ7zprwXP8EObDangWa+imojzavrjbdfnGts/GdDkp9pFfj0Pj+PzPkNgDjpkNKcA==", "7f4df67f-9fc5-4804-a8f7-29fe0ba3e483", "petya_guest@gmail.com" });

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "c393751e-8997-48a1-a325-32188af28241", "nasko_publisher@gmail.com", "NASKO_PUBLISHER@GMAIL.COM", "NASKO_PUBLISHER@GMAIL.COM", "AQAAAAIAAYagAAAAEHHdrDF3/j3QsX+PBJ2446HKiYnyGOJTn9zBFpLM1vlcFRPeB3/U2IKErUYZ9S7KEg==", "a7f0115a-17de-460a-89e0-23c20cd0600b", "nasko_publisher@gmail.com" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c8eb412-65a9-4050-8c67-62278f3af93c",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2744037d-78f2-4cd3-97e4-adfdac0378a3", "guest@gmail.com", "GUEST@GMAIL.COM", "GUEST@GMAIL.COM", "AQAAAAIAAYagAAAAEGxuZEyv251x+kUEyeoZzF7ZX3DDd21vb9ToXC6dKSDIHBvV2nsWkVMTk9bsSPxNkQ==", "37f626b0-b563-4a85-9b6c-a60a63232bd5", "guest@gmail.com" });

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
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "24951978-0dea-4c66-bc66-2f595c537a10", "publisher@gmail.com", "PUBLISHER@GMAIL.COM", "PUBLISHER@GMAIL.COM", "AQAAAAIAAYagAAAAEEcPM3je7SGl03xKE3NDT5jaKXB384Tq4Su27aIzrVwV8nB/JIEsr01JvNshDQpBDg==", "bf9e65c6-7c52-49cf-8d4d-7ec79e1e176f", "publisher@gmail.com" });

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
        }
    }
}
