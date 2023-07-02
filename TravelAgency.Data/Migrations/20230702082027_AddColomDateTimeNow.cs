using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class AddColomDateTimeNow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PricePerMonth",
                table: "Houses",
                newName: "Price");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Houses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 7, 2, 11, 20, 27, 167, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Double room" },
                    { 2, "Studio" },
                    { 3, "Apartment" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sozopol" },
                    { 2, "Primorsko" },
                    { 3, "Kiten" }
                });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CityId", "Description", "ImageUrl", "Price", "RenterId", "Title" },
                values: new object[] { new Guid("16ef5f6c-6f1b-4643-828d-954a7c96f1bb"), "Lozengrad 15", new Guid("951bd3ff-53e2-49c4-a272-19d7ec7cfb14"), 1, 1, "Малък семеен хотел в новата част на Созопол. намира се събсем близо до плажа.", "https://scontent.fsof1-1.fna.fbcdn.net/v/t1.6435-9/100680496_278314133535432_5456391328319406080_n.jpg?_nc_cat=111&cb=99be929b-3346023f&ccb=1-7&_nc_sid=730e14&_nc_ohc=RQpXwJhHdZ8AX_Zk1Ij&_nc_ht=scontent.fsof1-1.fna&oh=00_AfBao85ltJ0fFXEO_3zyFBC7IudFxDoxuQfOT-3Lzt8mtg&oe=64C4CE8C", 0m, null, "Morska zvezda" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CityId", "Description", "ImageUrl", "Price", "RenterId", "Title" },
                values: new object[] { new Guid("b0be9466-e5ea-404e-bf66-2fafe69e78c3"), "Republikanska 37", new Guid("951bd3ff-53e2-49c4-a272-19d7ec7cfb14"), 1, 1, "Хотел „Табанов бийч” е разположен в новата част на град Созопол. Намира се само на 60м. от плаж \"Хармани\", а в близост има много магазини, ресторанти, клубове и други развлечения..", "http://www.tabanovhotel.com/images/slide1.jpg", 0m, null, "Tabanov Beach" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("16ef5f6c-6f1b-4643-828d-954a7c96f1bb"));

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: new Guid("b0be9466-e5ea-404e-bf66-2fafe69e78c3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Houses");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Houses",
                newName: "PricePerMonth");
        }
    }
}
