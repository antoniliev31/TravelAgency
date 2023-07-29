using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _290723Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLists_AspNetUsers_UserId",
                table: "OrderLists");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderLists_Hotels_HotelId",
                table: "OrderLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderLists",
                table: "OrderLists");

            migrationBuilder.RenameTable(
                name: "OrderLists",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLists_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLists_HotelId",
                table: "Orders",
                newName: "IX_Orders_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7b95957-a278-47a3-98ec-775aa6410934", "AQAAAAEAACcQAAAAEG8f4eS/EyOAK/pcV8ToCehIqoubGJRB+X8HYvKw3WATu/mCCvrwEMV8DzMAggrQfQ==", "4ab128f0-c53b-4da8-8014-79e02c3f6b31" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ecd1847-4761-4c86-ba90-4cbdf7a8a5cd", "AQAAAAEAACcQAAAAEAITKy8Zg69OrICUuVQgpRIhPbNtF5SFsEo0uJqGF5q86KZtLN2G33YTRJS4zO7Djg==", "609f3a25-6d23-4c8a-8422-2f4339353df5" });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Hotels_HotelId",
                table: "Orders",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hotels_HotelId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderLists");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "OrderLists",
                newName: "IX_OrderLists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_HotelId",
                table: "OrderLists",
                newName: "IX_OrderLists_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderLists",
                table: "OrderLists",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLists_AspNetUsers_UserId",
                table: "OrderLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLists_Hotels_HotelId",
                table: "OrderLists",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
