using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class IpdateHotelInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 21, 1, 2, 486, DateTimeKind.Local).AddTicks(8965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 17, 52, 43, 247, DateTimeKind.Local).AddTicks(6168));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f7d2eb7-0195-4a5f-bf21-5850cde479cc", "AQAAAAEAACcQAAAAEChXeEgOvcryYr1ZJzihdoY8udVIPl15uitbGZuWV4pNjL7/6umnH65+7KCEeBmNJg==", "661c7f9b-3a51-4606-80e9-fa3fd782b840" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6280dd3-a581-4130-ba1a-b128b5711282", "AQAAAAEAACcQAAAAEEQr/u/f9NYB2P9bM6xO6fYz4WyfNYj/x07kMrtz2K4ng6XJkNOvlfMe1N12GRPT5g==", "0df8df9c-e218-4c06-8c22-6f2a1deee940" });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AgentId", "CategoryId", "CateringTypeId", "Description", "IsActive", "LocationId", "Price", "RoomTypeId", "Star", "Title" },
                values: new object[,]
                {
                    { 7, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 1, 1, "Къща за гости Дари се намира в новата част на античния град Созопол. Тя е разположена между два плажа на разстояние 5 - 6 минути от всеки плаж. Къщата се намира на тиха и спокойна улица, която дава възможност на туристите за пълноценна почивка. Къщата за гости разполага със самостоятелни стаи и апартаменти. Всички помещения са с тераса, санитарен възел, телевизор, хладилник, климатик и безплатен интернет.", true, 1, 100m, 1, 3, "ВИЛА ДАРИ" },
                    { 8, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 1, 3, "Разположен върху живописни скали на морския бряг в новата част на града, хотел „Фиорд” е идеален за мечтаната почивка. Плаж „Хармани” се намира на 60м. Хотелът разполага с еднакво обзаведени Двойни стаи от различен тип, различаващи се по площта си.", true, 1, 160m, 1, 3, "ХОРИЗОНТ" },
                    { 9, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 1, 3, "Разположен върху живописни скали на морския бряг в новата част на града, хотел „Фиорд” е идеален за мечтаната почивка. Плаж „Хармани” се намира на 60м. Хотелът разполага с еднакво обзаведени Двойни стаи от различен тип, различаващи се по площта си.", true, 1, 130m, 1, 3, "ФИОРД" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 35, 7, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/155/big/New%20Image.JPG", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 36, 7, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/155/big/DARI-2%20izgled.JPG" },
                    { 37, 7, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/155/big/DARI-staya.JPG" },
                    { 38, 7, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/155/big/DARI-%20NOMER%202.JPG" },
                    { 39, 7, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/155/big/DARI-%20NOMER%202.2.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 40, 8, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/33/big/CRW_4068.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 41, 8, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/33/big/150815_289__MG_5112.jpg" },
                    { 42, 8, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/33/big/150815_289__MG_5038-HDR.jpg" },
                    { 43, 8, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/33/big/IMG_4450.JPGg" },
                    { 44, 8, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/33/big/IMG_4495.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 45, 9, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/15/big/DSC_0063.JPG", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 46, 9, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/15/big/Hotel%20Fjord%20B1_6.jpg" },
                    { 47, 9, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/15/big/DSC_0063.JPG" },
                    { 48, 9, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/15/big/Hotel%20Fjord%20A_1.jpg" },
                    { 49, 9, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/15/big/Hotel%20Fjord%20Sozopol%20breakfast-7.JPG" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 15, 17, 52, 43, 247, DateTimeKind.Local).AddTicks(6168),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 15, 21, 1, 2, 486, DateTimeKind.Local).AddTicks(8965));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc6ea2c2-5ac8-4412-b94b-1b8f091762e4", "AQAAAAEAACcQAAAAEKywNB+kmZIhXvpa8qnEU0CB3bP9cYib1JusD/4yffHolRGNkRflP4VaL2I0E4sJCw==", "136df49b-daa5-4092-8fb6-2549a6436cbb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdff8ece-fd4d-4784-bf16-542ecf135e55", "AQAAAAEAACcQAAAAEHvMNZmpRgagfmLUoJE92PiNNNq9OtRI5Zup7yem+lF9rMDo1ZxY0kp95hvBKV0Hfg==", "dd39398a-455e-4429-8b3d-edd1335f7cf4" });
        }
    }
}
