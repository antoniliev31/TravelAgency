using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class TypeRoomPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Hotels",
                newName: "StudioRoomPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ApartmentRoomPrice",
                table: "Hotels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DoubleRoomPrice",
                table: "Hotels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6963288d-1285-4a11-ac51-457af408e80d", "AQAAAAEAACcQAAAAEIj+U749cCUZBfMMzib4YoWse1DXH/VmQ2jDzQvoYZnshHI8yFZgcXUO1TM7o1AxQQ==", "dac09171-b0fc-44c0-960f-cf7fd73dff98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59a92058-fed9-4530-8ede-63c6cfa044e2", "AQAAAAEAACcQAAAAEN3IJRJdheLDP9WIpKmC2GAq++uU4WmZCeXrZislokmYbEa/0ka7dD+czgECeEb9Fg==", "99d8d6db-7e1c-460c-a3e2-79a55917e042" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 100m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 120m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 120m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 120m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 170m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 200m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 100m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 160m, 0m });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DoubleRoomPrice", "StudioRoomPrice" },
                values: new object[] { 130m, 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentRoomPrice",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "DoubleRoomPrice",
                table: "Hotels");

            migrationBuilder.RenameColumn(
                name: "StudioRoomPrice",
                table: "Hotels",
                newName: "Price");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cca9c1c8-7075-4d7f-b33d-a4986c99ed55", "AQAAAAEAACcQAAAAEP7b81ost7krIoKCMoD7hFtGDLz0Zig2MGyn27iq4Xi5H31Bxe+zR0vNgTRiAMnOQQ==", "2f12a12d-501b-4dea-8e73-f80cf973e0ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82bf331e-d842-4f0c-9640-0cdc7992a3a7", "AQAAAAEAACcQAAAAEGLc76wiTg4yK19wsK8moJwRlkFEfw0YtHnPqjKACnZVxEwpslm1ftha8aNOJCyjhg==", "559b0979-9b02-4709-afec-35c4028dbe01" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 120m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 120m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 120m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 170m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "Price",
                value: 200m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "Price",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                column: "Price",
                value: 160m);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                column: "Price",
                value: 130m);
        }
    }
}
