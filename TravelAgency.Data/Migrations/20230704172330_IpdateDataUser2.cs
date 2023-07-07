using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class IpdateDataUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 20, 23, 29, 391, DateTimeKind.Local).AddTicks(5350),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 20, 18, 25, 839, DateTimeKind.Local).AddTicks(751));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c74336d-2aa4-46ca-a6e7-d3df80c388a9", "AQAAAAEAACcQAAAAEAkX7Umja8HtXpAPCNS31Ch/gMJ7XfkNyuKwRRyiW+l5TTVayJzBzKiabYLScv690Q==", "879f6c33-84fc-4cfa-91e5-13ac6a541471" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "271488a2-4087-477c-a5f3-74cb6e4b0471", "AQAAAAEAACcQAAAAEKSCd/wmu6pV1jUhH8pMg55V893SZwup+Jzmc1Tv9+jmN4TiMbfUHI98nzUG1IdUpg==", "e057d005-4764-4020-a03f-839363f66fb3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 4, 20, 18, 25, 839, DateTimeKind.Local).AddTicks(751),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 4, 20, 23, 29, 391, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "966a1a5b-7e9d-4919-95e0-cd3896b837be", "AQAAAAEAACcQAAAAEIYxwCwS2UiI1UKpGDxDdo0VYLu2XRUVQU88ZfidqdlZ/9pVSQsd3SiEXNVfrwif2A==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfcfc3b6-534f-406b-a5b6-8ff810a0c585", "AQAAAAEAACcQAAAAECNuLCL7kwpDHyUR3nGxH83Gc1VXfPBx1AlO0yIRmLypg3e6F62IYNCpQEE8U9yDJA==", null });
        }
    }
}
