using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _140723AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 14, 18, 2, 6, 398, DateTimeKind.Local).AddTicks(603),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 14, 17, 57, 40, 775, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f95f4632-08ed-41f1-bf5c-ae1d2df98a69", "AQAAAAEAACcQAAAAEOKJqz+eUu8R3qnZ4U1KLN3ZOtLWlXL2GWkrugITymFmbJqWsq249mQqlL7FojvzdQ==", "9d1789c9-8476-4a34-8d57-b420d7a2e459" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85a01249-a4c4-485a-92d3-a65680d317cc", "AQAAAAEAACcQAAAAEJeh7UEWxHL8XBVhrsCb9DuEdSShis1cSD1N9ePmwl1ChG7KCbtThYMtJWAwqzaPbA==", "e455a691-fb1a-45fa-819f-bde4d2d8843c" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 5, new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/IMG_4383.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 6, new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/IMG_4543.jpg" },
                    { 7, new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4025.jpg" },
                    { 8, new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4026.jpg" },
                    { 9, new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4033.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 10, new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/RXES.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 11, new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0686.JPG" },
                    { 12, new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0676.JPG" },
                    { 13, new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0672.JPG" },
                    { 14, new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0685.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 15, new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/B7NF.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 16, new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/Z4Y7.jpg" },
                    { 17, new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/DSC_0114.JPG" },
                    { 18, new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/DSC_0115.JPG" },
                    { 19, new Guid("492c853a-1a74-4c33-abe7-8c4397adf7f6"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/58MB.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 20, new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"), "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000721.JPG", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 21, new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"), "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000761.JPG" },
                    { 22, new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"), "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000760.JPG" },
                    { 23, new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"), "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000736.JPG" },
                    { 24, new Guid("47335a79-9f0e-4a2b-8ad2-9b8457ec32aa"), "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000718.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 25, new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"), "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0826.JPG", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 26, new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"), "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/P8270161.JPG" },
                    { 27, new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"), "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/P8270157.JPG" },
                    { 28, new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"), "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0883.JPG" },
                    { 29, new Guid("434a4b47-2dac-4ae7-9c3e-ae798703084c"), "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0882.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 30, new Guid("81713a06-e127-4970-934e-88added77a49"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/1.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 31, new Guid("81713a06-e127-4970-934e-88added77a49"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7398.jpg" },
                    { 32, new Guid("81713a06-e127-4970-934e-88added77a49"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7250.jpg" },
                    { 33, new Guid("81713a06-e127-4970-934e-88added77a49"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7275.jpg" },
                    { 34, new Guid("81713a06-e127-4970-934e-88added77a49"), "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/3.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 14, 17, 57, 40, 775, DateTimeKind.Local).AddTicks(1854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 7, 14, 18, 2, 6, 398, DateTimeKind.Local).AddTicks(603));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac9f7d21-f18f-4bc5-b201-fed566afd5b5", "AQAAAAEAACcQAAAAEBJdAX43KqOAoQyU1/7Onh/P001BoWz0luGM93Nu5K80a/Z9vlh0iFuwDEQ4UlI/pw==", "ac5ce453-dfaa-49e2-bccb-5a83a94a41e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cf9b51d-739b-48d7-b57b-904105f58467", "AQAAAAEAACcQAAAAEGzI5l5hIPUTZUH4AeXQx5kaeD8KPjIR4JcmeXTzapIKb5aGWD7N2oOJM6l/eNNd3Q==", "5cff1bd0-2cac-4140-929f-b22b72a2ed05" });
        }
    }
}
