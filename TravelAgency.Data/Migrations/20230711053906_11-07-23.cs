using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _110723 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_ApplicationUserId",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_ApplicationUserId1",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_ApplicationUserId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_ApplicationUserId1",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Hotels");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 11, 8, 39, 5, 124, DateTimeKind.Local).AddTicks(7831),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 10, 9, 5, 30, 767, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.CreateTable(
                name: "OrderLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLists_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishLists_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52f69581-c9e2-474a-86ed-6eb76c7594ce", "AQAAAAEAACcQAAAAEDpupTGMMIc6Ugirgt8S7no2ugrZ3lvpu1mclptwLpOk26Mc36e7ssN6TzIqKtG6dg==", "549ac14c-a39f-4fe5-9712-a67c12a5cebc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14137eed-e367-4237-b08f-0c377e63cc04", "AQAAAAEAACcQAAAAEEMGmJmuFN9aLgoIWoZ8ZRmjSj+GEvWbKZhjfsT0jzzSkrgwIF/S7Mqwfq2KWCwROA==", "3fcaf72e-bbdd-4aff-8b4b-5f398aa04d8f" });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_HotelId",
                table: "OrderLists",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_UserId",
                table: "OrderLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_HotelId",
                table: "WishLists",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLists");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 9, 5, 30, 767, DateTimeKind.Local).AddTicks(7165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 11, 8, 39, 5, 124, DateTimeKind.Local).AddTicks(7831));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Hotels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId1",
                table: "Hotels",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fe9d563-2dde-46ef-972b-470e5ee9e635", "AQAAAAEAACcQAAAAEPKZNzulhsIxTQg180YMj0btAqG7ZWGWLMmaUuySwRtglhPY26fsfLuiHsSUE+/5YA==", "4c06e8be-dc58-4d3a-9617-20dc703bcc4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81c696a3-a45a-42bb-9344-7b2ad10a1189", "AQAAAAEAACcQAAAAENOkupNJIKVfV4TZ5jkpX+yvR/Rt63H1PoqBtZvLYowFvCumYJnY42247+zLrtX9TA==", "86f3122e-d279-43d2-bec5-946a32f703b5" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("81713a06-e127-4970-934e-88added77a49"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"),
                column: "IsActive",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_ApplicationUserId",
                table: "Hotels",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_ApplicationUserId1",
                table: "Hotels",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_ApplicationUserId",
                table: "Hotels",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_ApplicationUserId1",
                table: "Hotels",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
