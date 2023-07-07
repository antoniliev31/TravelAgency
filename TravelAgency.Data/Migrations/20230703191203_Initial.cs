using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 7, 3, 22, 12, 3, 246, DateTimeKind.Local).AddTicks(5667)),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActiv = table.Column<byte>(type: "tinyint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Houses_AspNetUsers_RenterId",
                        column: x => x.RenterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Houses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), 0, "05d07851-9c0d-4602-aa1c-43e260626377", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEI/xGLxNCdy4FV7v5vG18IwXVg+/hsalaOb4lVhJL6qzhUv/kQMi93lsKIjwVkSxJw==", null, false, null, false, "guest@mail.com" },
                    { new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 0, "dc415167-8756-446a-9cc7-50b0971f39ce", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEA7Spi+MgeTLygsMgcqeOQmHfUR2T1+V1Y/RERsa75jIdiJICd/q3wr5ukwdonGoOQ==", null, false, null, false, "agent@mail.com" }
                });

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
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), "+359888888888", new Guid("dea12856-c198-4129-b3f3-b893d8395082") });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CityId", "Description", "ImageUrl", "IsActiv", "Price", "RenterId", "Title" },
                values: new object[] { new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), "Lozengrad 15", new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 1, 1, "Малък семеен хотел в новата част на Созопол. намира се събсем близо до плажа.", "https://scontent.fsof1-1.fna.fbcdn.net/v/t1.6435-9/100680496_278314133535432_5456391328319406080_n.jpg?_nc_cat=111&cb=99be929b-3346023f&ccb=1-7&_nc_sid=730e14&_nc_ohc=RQpXwJhHdZ8AX_Zk1Ij&_nc_ht=scontent.fsof1-1.fna&oh=00_AfBao85ltJ0fFXEO_3zyFBC7IudFxDoxuQfOT-3Lzt8mtg&oe=64C4CE8C", (byte)0, 0m, null, "Morska zvezda" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Address", "AgentId", "CategoryId", "CityId", "Description", "ImageUrl", "IsActiv", "Price", "RenterId", "Title" },
                values: new object[] { new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), "Republikanska 37", new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 1, 1, "Хотел „Табанов бийч” е разположен в новата част на град Созопол. Намира се само на 60м. от плаж \"Хармани\", а в близост има много магазини, ресторанти, клубове и други развлечения..", "http://www.tabanovhotel.com/images/slide1.jpg", (byte)0, 0m, null, "Tabanov Beach" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "HouseId", "UserId" },
                values: new object[,]
                {
                    { 1, "Прекрасно преживяване в хотела! Уютна стая, отлично обслужване и изискан ресторант. Няма как да не се чувстваш приветливо посрещнат и релаксиран. Препоръчвам", new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 2, "Къщата за гости беше просто превъзходна! Прекарахме незабравим уикенд сред природата, в компанията на любезни домакини. Всичко беше перфектно - от удобствата до гледката. С удоволствие ще се върнем отново!", new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 3, "Невероятно преживяване в този хотел. Спокойствие, лукс и безупречно обслужване. От момента на пристигането до заминаването си се чувствахме като VIP гости. Благодарим на персонала за прекрасния престой!", new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 4, "Хотелът ни очарова с уникален дизайн и стил. Всяка детайлна измислица беше внимателно изпълнена. Спяхме в комфортен легловия аранжимент и се насладихме на изисканата храна. Подгответе се за неповторимо изживяване!", new Guid("03a5df20-bd50-4d95-b674-00ec170b9212"), new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 5, "Къщата за гости беше уютна и пълна със сърце и душа. Гостоприемните домакини ни посрещнаха с топлина и готвената храна беше вкусна и автентична. Проведохме спокоен и релаксиращ уикенд в прекрасна обстановка.", new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 6, "Семейният ни престой в този хотел беше мечтан. Басейнът и игралната зала развълнуваха децата, докато спа-центърът ни предложи наистина релаксиращ опит. Отлична комбинация от забавление и отдих!", new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), new Guid("dea12856-c198-4129-b3f3-b893d8395082") },
                    { 7, "Избрахме тази къща за гости за нашата романтична почивка и не бихме могли да бъдем по-щастливи. Атмосферата беше магична, а гледката от терасата буквално откъсна дъха. Ще я препоръчаме на всички!", new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), new Guid("dea12856-c198-4129-b3f3-b893d8395082") },
                    { 8, "Хотелът беше прекрасно решение за нашия семеен отдих. Паркът и детските площадки зарадваха децата, а ресторантът ни предложи невероятни вкусове. Прекарахме незабравимо време с любимите си хора.", new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), new Guid("dea12856-c198-4129-b3f3-b893d8395082") },
                    { 9, "Невероятна къща за гости, вложена със стил и комфорт. Пълноценното оборудване и уютната атмосфера ни позволиха да се отпуснем напълно. Прекарахме прекрасна почивка сред природата.", new Guid("91a6ce15-9413-4e04-8393-d48d651e09fc"), new Guid("dea12856-c198-4129-b3f3-b893d8395082") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AgentId",
                table: "Houses",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CategoryId",
                table: "Houses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CityId",
                table: "Houses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_RenterId",
                table: "Houses",
                column: "RenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_HouseId",
                table: "Posts",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
