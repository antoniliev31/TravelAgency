using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _1107234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 12, 36, 27, 773, DateTimeKind.Local).AddTicks(1439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 9, 28, 58, 644, DateTimeKind.Local).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5ffffe9-7e41-4933-96bf-ac939283de69", "AQAAAAEAACcQAAAAEKB5OccUNPHdk4ufamFRKnvtn45KSpJn8mueEXF4/UCPB/LzC5BjAZFh7BgsKnuMHg==", "3120800b-22a7-4ce7-b1ec-552c5d7ab823" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e982c04-a4f2-4570-a142-e5b7977b1472", "AQAAAAEAACcQAAAAENzfNKnD0y+AwxZlNMo2mzGYZAGhgnfc5YtRdvKxHxbaGr5UXQGSk+xITh6eswmlbA==", "c232824e-0dfd-46fa-abaa-b8d6343f64ee" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("81713a06-e127-4970-934e-88added77a49"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"),
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "IsActive",
                table: "Hotels",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 9, 28, 58, 644, DateTimeKind.Local).AddTicks(2127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 12, 36, 27, 773, DateTimeKind.Local).AddTicks(1439));

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
    }
}
