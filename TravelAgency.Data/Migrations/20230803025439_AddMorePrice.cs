using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class AddMorePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudioRoomPrice",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudioRoomPrice",
                value: 150m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApartmentRoomPrice",
                value: 200m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2547e13b-507d-42d4-88f3-06f888d89e1c", "AQAAAAEAACcQAAAAEOQuNUFCWqV1n8dTFVkVDwJgjA4Qb0bocRIrGAr87H0M431eb45zJ+HvmZm4nUcuVA==", "aa892ebd-af3a-49cb-8a85-10f5ca34b3f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff37cc49-89b5-444c-808e-c4a7f12e1400", "AQAAAAEAACcQAAAAECPnoYMIisxuwDO6LnbHTonD0DoNDB6PvAvm5gVFNZhtdVhHP+0JJa97VYd52ITeKw==", "f015edae-86e1-42fc-88f9-301d47bc4416" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "StudioRoomPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudioRoomPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApartmentRoomPrice",
                value: 0m);
        }
    }
}
