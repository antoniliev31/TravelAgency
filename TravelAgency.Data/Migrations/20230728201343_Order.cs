using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLists_RoomTypes_RoomTypeId",
                table: "OrderLists");

            migrationBuilder.DropIndex(
                name: "IX_OrderLists_RoomTypeId",
                table: "OrderLists");

            migrationBuilder.DropColumn(
                name: "RoomTypeId",
                table: "OrderLists");

            migrationBuilder.AddColumn<string>(
                name: "RoomType",
                table: "OrderLists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "786dc529-d9d1-49dd-9a53-096c06874753", "AQAAAAEAACcQAAAAEDV7SGbq07FjAtVzFhJO+A8Y3ueU9/cd1rcFci0g31sJkniL+Xuq+8XgZYZ8WjtVqQ==", "9dd7264c-3628-4395-803a-6faa5bf86353" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8149bb4-1858-4d61-83a3-fcd207b9dd40", "AQAAAAEAACcQAAAAEFWU8gn3sRFn85ZJdg9dKJtwk7oiC6Sk5KW2clf9CCum9ywnaqSzA7j/BqPpnzpsdQ==", "075a14a0-0980-4d51-8566-8232f13ee9ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomType",
                table: "OrderLists");

            migrationBuilder.AddColumn<int>(
                name: "RoomTypeId",
                table: "OrderLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
