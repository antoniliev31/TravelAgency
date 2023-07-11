using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _1107232 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 9, 26, 11, 929, DateTimeKind.Local).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 9, 23, 18, 16, DateTimeKind.Local).AddTicks(6618));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9ffae64-129d-42d7-9438-fbc84d831561", "AQAAAAEAACcQAAAAEIKnH58RcXG0hyDUfkVIxf1NceXndmd3lqlzDC5astKl9WEPZEZFMGrJ/v7czSx2kA==", "efd07bfb-929a-4635-ab31-367946a1ed52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e616129-cec6-4673-98ab-504646347d9a", "AQAAAAEAACcQAAAAEMQWiFGPdzCiUc1dfjjuLNPq8VkOS7hJw9uXSg1KvJsxE09qlWWJldxEk/eKlne4QA==", "3d6190a9-b97b-48e4-b147-365055e06ac7" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"),
                column: "IsActive",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"),
                column: "IsActive",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"),
                column: "IsActive",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"),
                column: "IsActive",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("81713a06-e127-4970-934e-88added77a49"),
                column: "IsActive",
                value: (byte)1);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"),
                column: "IsActive",
                value: (byte)1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 9, 23, 18, 16, DateTimeKind.Local).AddTicks(6618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 9, 26, 11, 929, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87257b8c-db46-4967-b059-47c278f13f26", "AQAAAAEAACcQAAAAEIybVaoEVvsS1nu+c10YsxhoeMR86v5Mb2OB5lrjEZ5QH/nRbKYZL0LbsZXWgW8twA==", "5be847c2-06a8-40a9-a460-95d134cbcdf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "547fa787-e097-4b20-8695-cdd04628d591", "AQAAAAEAACcQAAAAECtbdmITFI6bY5h9FuMiqGJeUpxKukLEW52OFweZ/P5xBaXH6Gr2GTtNSTftzGxEPA==", "c807e2bb-422c-447d-a5c0-1881274c6e21" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"),
                column: "IsActive",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"),
                column: "IsActive",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"),
                column: "IsActive",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"),
                column: "IsActive",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("81713a06-e127-4970-934e-88added77a49"),
                column: "IsActive",
                value: (byte)0);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"),
                column: "IsActive",
                value: (byte)0);
        }
    }
}
