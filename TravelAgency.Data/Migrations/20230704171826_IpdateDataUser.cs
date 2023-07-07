using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class IpdateDataUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 20, 18, 25, 839, DateTimeKind.Local).AddTicks(751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 3, 22, 12, 3, 246, DateTimeKind.Local).AddTicks(5667));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "966a1a5b-7e9d-4919-95e0-cd3896b837be", "AQAAAAEAACcQAAAAEIYxwCwS2UiI1UKpGDxDdo0VYLu2XRUVQU88ZfidqdlZ/9pVSQsd3SiEXNVfrwif2A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dfcfc3b6-534f-406b-a5b6-8ff810a0c585", "AQAAAAEAACcQAAAAECNuLCL7kwpDHyUR3nGxH83Gc1VXfPBx1AlO0yIRmLypg3e6F62IYNCpQEE8U9yDJA==" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"),
                column: "ImageUrl",
                value: "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/Z4Y7.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 3, 22, 12, 3, 246, DateTimeKind.Local).AddTicks(5667),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 20, 18, 25, 839, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "05d07851-9c0d-4602-aa1c-43e260626377", "AQAAAAEAACcQAAAAEI/xGLxNCdy4FV7v5vG18IwXVg+/hsalaOb4lVhJL6qzhUv/kQMi93lsKIjwVkSxJw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dc415167-8756-446a-9cc7-50b0971f39ce", "AQAAAAEAACcQAAAAEA7Spi+MgeTLygsMgcqeOQmHfUR2T1+V1Y/RERsa75jIdiJICd/q3wr5ukwdonGoOQ==" });

            migrationBuilder.UpdateData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"),
                column: "ImageUrl",
                value: "http://www.tabanovhotel.com/images/slide1.jpg");
        }
    }
}
