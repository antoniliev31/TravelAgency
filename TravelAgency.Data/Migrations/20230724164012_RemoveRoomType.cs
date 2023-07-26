using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class RemoveRoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_RoomTypes_RoomTypeId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_RoomTypeId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9fddb3a-27d3-4965-8512-9b625e668573", "AQAAAAEAACcQAAAAEJeC8wVF9UnibtFLawtgOI2ZLfnxzNivGPpClufgazQnD1BNEq7HhyHO405FjudpRg==", "f9be2d10-b44f-4236-b15d-77dc38dd04a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "364001ec-993f-4218-8df4-ca488d6a970c", "AQAAAAEAACcQAAAAEHkljLoLQ5ZPifvSfWMNoihRiSaEzWWJklgo1Weuj2GF44HVuh7QTtd6o0qaThv28w==", "2d8741ec-4098-4710-b53e-e2c99e892956" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                column: "RoomTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoomTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoomTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomTypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomTypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoomTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoomTypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoomTypeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_RoomTypeId",
                table: "Hotels",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_RoomTypes_RoomTypeId",
                table: "Hotels",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
