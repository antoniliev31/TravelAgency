using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Data.Migrations
{
    public partial class _150723UpdateHoteId : Migration
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
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CateringTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CateringTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
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
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Star = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 7, 15, 17, 52, 43, 247, DateTimeKind.Local).AddTicks(6168)),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CateringTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotels_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_CateringTypes_CateringTypeId",
                        column: x => x.CateringTypeId,
                        principalTable: "CateringTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hotels_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Posts_Hotels_HotelId",
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
                    HotelId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"), 0, "dc6ea2c2-5ac8-4412-b94b-1b8f091762e4", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEKywNB+kmZIhXvpa8qnEU0CB3bP9cYib1JusD/4yffHolRGNkRflP4VaL2I0E4sJCw==", null, false, "136df49b-daa5-4092-8fb6-2549a6436cbb", false, "guest@mail.com" },
                    { new Guid("dea12856-c198-4129-b3f3-b893d8395082"), 0, "bdff8ece-fd4d-4784-bf16-542ecf135e55", "agent@mail.com", false, false, null, "agent@mail.com", "agent@mail.com", "AQAAAAEAACcQAAAAEHvMNZmpRgagfmLUoJE92PiNNNq9OtRI5Zup7yem+lF9rMDo1ZxY0kp95hvBKV0Hfg==", null, false, "dd39398a-455e-4429-8b3d-edd1335f7cf4", false, "agent@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Семеен хотел" },
                    { 2, "Хотел" },
                    { 3, "Апартхотел" }
                });

            migrationBuilder.InsertData(
                table: "CateringTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "RoomOnly" },
                    { 2, "BedAndBreakfast" },
                    { 3, "HalfBoard" },
                    { 4, "FullBoard" },
                    { 5, "AllInclusive" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Созопол" },
                    { 2, "Черноморец" },
                    { 3, "Дюни" },
                    { 4, "Слънчев бряг" },
                    { 5, "Златни пясъци" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Double room" },
                    { 2, "Studio" },
                    { 3, "Apartment" }
                });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), "+359888888888", new Guid("dea12856-c198-4129-b3f3-b893d8395082") });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "AgentId", "CategoryId", "CateringTypeId", "Description", "IsActive", "LocationId", "Price", "RoomTypeId", "Star", "Title" },
                values: new object[,]
                {
                    { 1, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 1, 1, "Хотел в новата част на Созопол. Намира се събсем близо до плажа.", true, 1, 100m, 1, 4, "ЛАГУНА БИЙЧ" },
                    { 2, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 1, 2, "Хотел „Табанов бийч” е разположен в новата част на град Созопол. Намира се само на 60м. от плаж \"Хармани\", а в близост има много магазини, ресторанти, клубове и други развлечения..", true, 1, 120m, 1, 3, "ТАБАНОВ БИЙЧ" },
                    { 3, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 2, 2, "Хотел „Аполис” се намира на много тихо и спокойно място в новата част на града. Разположен е на 70 м от плаж Хармани. Той е уютен и луксозен хотел, с интересна архитектура.", true, 1, 120m, 1, 3, "АПОЛИС" },
                    { 4, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 2, 2, "Аполония Резорт е изискан четиризвезден ваканционен комплекс от затворен тип, разположен на един от най- красивите плажове по българското черноморие - великолепния Царския плаж. Царският плаж е разположен между курортите Черноморец на север и Созопол на юг.", true, 2, 120m, 2, 4, "АПОЛОНИЯ РЕЗОРТ" },
                    { 5, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 3, 2, "Хотел „Аркутино Фемили Ризорт “ се намира на южното Черноморие на 40 км от град Бургас, между Созопол и Приморско в местността Аркутино, която е част от резервата „Ропотамо“. Разположен е в непосредствена близост до един от най-красивите български плажове, между златисти пясъчни дюни, прочутото крайморско езеро Водните лилии и река Ропотамо.", true, 3, 170m, 2, 4, "АРКУТИНО ФЕМИЛИ РЕЗОРТ" },
                    { 6, new Guid("0174683e-a3fd-4f3c-a2b7-3c3792dad867"), 3, 2, "Аполония резорт е луксозен, апартаментен комплекс от затворен тип, състоящ се от две четири етажни сгради с капацитет от 23 апартамента. Апартаментите са от различен тип, напълно оборудвани с всичко необходимо за престоя на своите гости. Намира се в района на живописното черноморско градче Черноморец, на 400 м от центъра и на 300 м от златистия плаж. Хотелът разполага със собствен ресторант, където гостите ползват отстъпка.", true, 2, 200m, 3, 4, "АПОЛОНИЯ РЕЗОРТ" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 5, 1, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/IMG_4383.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 6, 1, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/IMG_4543.jpg" },
                    { 7, 1, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4025.jpg" },
                    { 8, 1, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4026.jpg" },
                    { 9, 1, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4033.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 10, 2, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/RXES.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 11, 2, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0686.JPG" },
                    { 12, 2, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0676.JPG" },
                    { 13, 2, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0672.JPG" },
                    { 14, 2, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0685.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 15, 3, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/B7NF.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 16, 3, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/Z4Y7.jpg" },
                    { 17, 3, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/DSC_0114.JPG" },
                    { 18, 3, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/DSC_0115.JPG" },
                    { 19, 3, "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/58MB.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 20, 4, "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000721.JPG", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 21, 4, "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000761.JPG" },
                    { 22, 4, "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000760.JPG" },
                    { 23, 4, "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000736.JPG" },
                    { 24, 4, "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000718.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 25, 5, "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0826.JPG", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 26, 5, "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/P8270161.JPG" },
                    { 27, 5, "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/P8270157.JPG" },
                    { 28, 5, "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0883.JPG" },
                    { 29, 5, "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0882.JPG" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "IsMain" },
                values: new object[] { 30, 6, "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/1.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl" },
                values: new object[,]
                {
                    { 31, 6, "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7398.jpg" },
                    { 32, 6, "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7250.jpg" },
                    { 33, 6, "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7275.jpg" },
                    { 34, 6, "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/3.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "HotelId", "UserId" },
                values: new object[,]
                {
                    { 1, "Прекрасно преживяване в хотела! Уютна стая, отлично обслужване и изискан ресторант. Няма как да не се чувстваш приветливо посрещнат и релаксиран. Препоръчвам", 1, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 2, "Къщата за гости беше просто превъзходна! Прекарахме незабравим уикенд сред природата, в компанията на любезни домакини. Всичко беше перфектно - от удобствата до гледката. С удоволствие ще се върнем отново!", 2, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 3, "Невероятно преживяване в този хотел. Спокойствие, лукс и безупречно обслужване. От момента на пристигането до заминаването си се чувствахме като VIP гости. Благодарим на персонала за прекрасния престой!", 3, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 4, "Хотелът ни очарова с уникален дизайн и стил. Всяка детайлна измислица беше внимателно изпълнена. Спяхме в комфортен легловия аранжимент и се насладихме на изисканата храна. Подгответе се за неповторимо изживяване!", 4, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 5, "Къщата за гости беше уютна и пълна със сърце и душа. Гостоприемните домакини ни посрещнаха с топлина и готвената храна беше вкусна и автентична. Проведохме спокоен и релаксиращ уикенд в прекрасна обстановка.", 5, new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e") },
                    { 6, "Семейният ни престой в този хотел беше мечтан. Басейнът и игралната зала развълнуваха децата, докато спа-центърът ни предложи наистина релаксиращ опит. Отлична комбинация от забавление и отдих!", 6, new Guid("dea12856-c198-4129-b3f3-b893d8395082") },
                    { 7, "Избрахме тази къща за гости за нашата романтична почивка и не бихме могли да бъдем по-щастливи. Атмосферата беше магична, а гледката от терасата буквално откъсна дъха. Ще я препоръчаме на всички!", 1, new Guid("dea12856-c198-4129-b3f3-b893d8395082") },
                    { 8, "Хотелът беше прекрасно решение за нашия семеен отдих. Паркът и детските площадки зарадваха децата, а ресторантът ни предложи невероятни вкусове. Прекарахме незабравимо време с любимите си хора.", 2, new Guid("dea12856-c198-4129-b3f3-b893d8395082") },
                    { 9, "Невероятна къща за гости, вложена със стил и комфорт. Пълноценното оборудване и уютната атмосфера ни позволиха да се отпуснем напълно. Прекарахме прекрасна почивка сред природата.", 3, new Guid("dea12856-c198-4129-b3f3-b893d8395082") }
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
                name: "IX_Hotels_AgentId",
                table: "Hotels",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CategoryId",
                table: "Hotels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CateringTypeId",
                table: "Hotels",
                column: "CateringTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LocationId",
                table: "Hotels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_RoomTypeId",
                table: "Hotels",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HotelId",
                table: "Images",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_HotelId",
                table: "OrderLists",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLists_UserId",
                table: "OrderLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_HotelId",
                table: "Posts",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
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
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderLists");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CateringTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
