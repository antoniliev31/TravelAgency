using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _260723AddOrderList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "RoomTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "OrderLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "OrderLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderLists",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "OrderLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "OrderLists",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "АccommodationDate",
                table: "OrderLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb56db36-9332-4fcd-8adc-17617882f9fb", "AQAAAAEAACcQAAAAEDjEJcdPGWL/NZ3pYatHKgMqW3Ed/DWqDD1JksnsXz8tteAuo7a7yKC1pEWCY6J6Yw==", "a7de8a00-dda6-4832-aeda-a6e4d1cd6c4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14d556bb-a101-4e2d-83a4-dd2605c7f4bb", "AQAAAAEAACcQAAAAEEJMeN3+2zJExExzwuZR9rIIaRsidu6pwviX16BKniHwMqg4AiYdru5xfIwcWhQy5A==", "113446b7-b46c-4a4c-a335-a54e5dbbe504" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_HotelId",
                table: "RoomTypes",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_RoomTypeId",
                table: "OrderLists",
                column: "RoomTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLists_RoomTypes_RoomTypeId",
                table: "OrderLists",
                column: "RoomTypeId",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypes_Hotels_HotelId",
                table: "RoomTypes",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLists_RoomTypes_RoomTypeId",
                table: "OrderLists");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypes_Hotels_HotelId",
                table: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_HotelId",
                table: "RoomTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderLists_RoomTypeId",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "АccommodationDate",
                table: "OrderLists");

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
    }
}
