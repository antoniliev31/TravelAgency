using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _100723 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplApplicationUserHotels");

            migrationBuilder.DropTable(
                name: "ApplicationUserHotel");

            migrationBuilder.DropTable(
                name: "ApplicationUserHotel1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 10, 9, 5, 30, 767, DateTimeKind.Local).AddTicks(7165),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 9, 17, 9, 49, 222, DateTimeKind.Local).AddTicks(7889));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 7, 9, 17, 9, 49, 222, DateTimeKind.Local).AddTicks(7889),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 10, 9, 5, 30, 767, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.CreateTable(
                name: "AplApplicationUserHotels",
                columns: table => new
                {
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplApplicationUserHotels", x => new { x.ApplicationUserId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_AplApplicationUserHotels_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplApplicationUserHotels_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserHotel",
                columns: table => new
                {
                    LikedHotelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersWhoLikedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserHotel", x => new { x.LikedHotelsId, x.UsersWhoLikedId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserHotel_AspNetUsers_UsersWhoLikedId",
                        column: x => x.UsersWhoLikedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserHotel_Hotels_LikedHotelsId",
                        column: x => x.LikedHotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserHotel1",
                columns: table => new
                {
                    BookedHotelsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersWhoBookedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserHotel1", x => new { x.BookedHotelsId, x.UsersWhoBookedId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserHotel1_AspNetUsers_UsersWhoBookedId",
                        column: x => x.UsersWhoBookedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserHotel1_Hotels_BookedHotelsId",
                        column: x => x.BookedHotelsId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7abcee83-16aa-4c4e-9d14-843c66ebb9d8", "AQAAAAEAACcQAAAAEOYyTukWl6YrgRp76Kv62bPacA4RPliRav1fsJMksrOst/yCNrszIL3ZXCR3MyQ4Ug==", "f40056d6-00dd-441c-a283-eda8df2e1f98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "548b9c29-bef9-4c66-bb5c-ec4ca835f5f6", "AQAAAAEAACcQAAAAEPrik8fHc89DsvB4zzMMBJdutduDOXxYlbA4XBUmtQprQAvNSdDRUKvRiVDfYmDeRA==", "448fc011-a63a-4be2-b88f-0bcc6e89ca63" });

            migrationBuilder.CreateIndex(
                name: "IX_AplApplicationUserHotels_HotelId",
                table: "AplApplicationUserHotels",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHotel_UsersWhoLikedId",
                table: "ApplicationUserHotel",
                column: "UsersWhoLikedId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserHotel1_UsersWhoBookedId",
                table: "ApplicationUserHotel1",
                column: "UsersWhoBookedId");
        }
    }
}
