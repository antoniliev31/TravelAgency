using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class AddFirstAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68a127f5-4e87-4d8d-918f-f20376c2ee14", "Georgi", "Georgiev", "AQAAAAEAACcQAAAAEAce1jKTs5OfTjKWOCTD1gFSWAv1fFXsKzX9qWQ5OytbrTTTxQPNGL7JKTM3dIJtJQ==", "d3f745c7-f092-40f3-909c-b6c494f1d847" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ecaa8ff-595e-4182-99f9-26b81d3bd9cf", "Ivan", "Ivanov", "AQAAAAEAACcQAAAAENuLGDAliaedOf3VM9+5ju+P569/1QRH/7wQdy3k5caGHYFfKSveIkL4BBb3jrpd0g==", "50624042-2d3b-4fd8-9fa6-df8f641961a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04580a68-d796-4697-b721-71581fae9065", "AQAAAAEAACcQAAAAEA1zkd22aFmXS+OXGceGYOP6g/fZ0RY6i3zW+Cg0Mpiur2x6Us8kKTng2cELWQapew==", "7579991e-12f0-4646-a24a-fdc786945487" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07a3b5fd-8573-4501-8237-74e11234fe49", "AQAAAAEAACcQAAAAEBSs7YaxH5QfTIoiwcZ1kgqWVK1pdK49/7Ajzs1INDvIWIp2dHIGTXyEfGngdIZUuA==", "944719c3-d147-4336-9715-a7bac69cdb8a" });
        }
    }
}
