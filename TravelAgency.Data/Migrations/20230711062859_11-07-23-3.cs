using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _1107233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 9, 28, 58, 644, DateTimeKind.Local).AddTicks(2127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 9, 26, 11, 929, DateTimeKind.Local).AddTicks(1303));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13ef4d4d-a840-46bd-be48-a8929f3b202b", "AQAAAAEAACcQAAAAEIHnNTA3BgQnG0SUFqqGpgl1Ukoz6DmfIvrJHmvaCDM3frajQk5qoZeiuNgwkHe8Xw==", "abf158a4-5d9c-4921-96fd-a8edea01ca8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce731935-4fba-48da-bcf0-621dd0c41997", "AQAAAAEAACcQAAAAENfDpOQVS2Fj9flsLIOdJeZPfR5GVwv05IhjiqvRBVI6PU/LzijUyLjHUNOhUXsPsw==", "2b4615f5-3cb0-4e15-8ce4-f85c2c3e0093" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 9, 26, 11, 929, DateTimeKind.Local).AddTicks(1303),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 9, 28, 58, 644, DateTimeKind.Local).AddTicks(2127));

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
        }
    }
}
