using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class AddAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a175447-f404-476d-bbbe-e2faf950a3b3", "AQAAAAEAACcQAAAAEGwH02njqJa48dK8Ha1BjfTY42Q53J+lDa1K2OYJFYXq+xsj6xpzqqGpaLObi6p6Cw==", "526eaf38-dec5-474e-89cc-38a38f6db5cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2b3cbd0-86e2-4ab0-ad98-d29fd61fbe88", "AQAAAAEAACcQAAAAECAJXDKteAmZSG48LQvCd4wlwcTn8p5WIu5DD4IxcqB+fVs4EDexamqZ7ArqRhJcsA==", "e3207924-43dd-487f-a651-17904a7c46c2" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("949a14ed-2e82-4f5a-a684-a9c7e3ccb52e"), 0, "51a875b3-0cc7-4ebb-9b1c-9b971ffd0b3f", "admin@admin.com", false, "Admin", "Admin", false, null, "ADMIN@ADMIN.com", "ADMIN@ADMIN.com", "AQAAAAEAACcQAAAAEEe7bZX4wJsrQh3IK4g52sJ/wyJhGXT10SqacYmocJTi9QtihCmALlw6EUc1+uFVxw==", null, false, "40624b22-a669-4a09-913e-b457063360b8", false, "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("949a14ed-2e82-4f5a-a684-a9c7e3ccb52e"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68a127f5-4e87-4d8d-918f-f20376c2ee14", "AQAAAAEAACcQAAAAEAce1jKTs5OfTjKWOCTD1gFSWAv1fFXsKzX9qWQ5OytbrTTTxQPNGL7JKTM3dIJtJQ==", "d3f745c7-f092-40f3-909c-b6c494f1d847" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ecaa8ff-595e-4182-99f9-26b81d3bd9cf", "AQAAAAEAACcQAAAAENuLGDAliaedOf3VM9+5ju+P569/1QRH/7wQdy3k5caGHYFfKSveIkL4BBb3jrpd0g==", "50624042-2d3b-4fd8-9fa6-df8f641961a7" });
        }
    }
}
