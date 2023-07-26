namespace TravelAgency.Data.Configurations
{
    using Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class HotelEntityConfigurations : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(h => h.IsActive)
                .HasDefaultValue(true);

            builder
                .HasOne(h => h.Location)
                .WithMany(c => c.HotelsInThisLocation)
                .HasForeignKey(h => h.LocationId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(h => h.Agent)
                .WithMany(a => a.OwnedHotel)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(this.GenerateHotels());
        }

        private Hotel[] GenerateHotels()
        {
            ICollection<Hotel> hotels = new HashSet<Hotel>();

            Hotel hotel;
            hotel = new Hotel
            {
                Id = 1,
                Title = "ЛАГУНА БИЙЧ",
                LocationId = 1,
                Description = "Хотел в новата част на Созопол. Намира се събсем близо до плажа.",
                CategoryId = 1,
                CateringTypeId = 1,
                Star = 4,
                DoubleRoomPrice = 100,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 2,
                Title = "ТАБАНОВ БИЙЧ",
                LocationId = 1,
                Description = "Хотел „Табанов бийч” е разположен в новата част на град Созопол. Намира се само на 60м. от плаж \"Хармани\", а в близост има много магазини, ресторанти, клубове и други развлечения..",
                CategoryId = 1,
                CateringTypeId = 2,
                Star = 3,
                DoubleRoomPrice = 120,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);


            hotel = new Hotel()
            {
                Id = 3,
                Title = "АПОЛИС",
                LocationId = 1,
                Description = "Хотел „Аполис” се намира на много тихо и спокойно място в новата част на града. Разположен е на 70 м от плаж Хармани. Той е уютен и луксозен хотел, с интересна архитектура.",
                CategoryId = 2,
                CateringTypeId = 2,
                Star = 3,
                DoubleRoomPrice = 120,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 4,
                Title = "АПОЛОНИЯ РЕЗОРТ",
                LocationId = 2,
                Description = "Аполония Резорт е изискан четиризвезден ваканционен комплекс от затворен тип, разположен на един от най- красивите плажове по българското черноморие - великолепния Царския плаж. Царският плаж е разположен между курортите Черноморец на север и Созопол на юг.",
                CategoryId = 2,
                CateringTypeId = 2,
                Star = 4,
                DoubleRoomPrice = 120,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 5,
                Title = "АРКУТИНО ФЕМИЛИ РЕЗОРТ",
                LocationId = 3,
                Description = "Хотел „Аркутино Фемили Ризорт “ се намира на южното Черноморие на 40 км от град Бургас, между Созопол и Приморско в местността Аркутино, която е част от резервата „Ропотамо“. Разположен е в непосредствена близост до един от най-красивите български плажове, между златисти пясъчни дюни, прочутото крайморско езеро Водните лилии и река Ропотамо.",
                CategoryId = 3,
                CateringTypeId = 2,
                Star = 4,
                DoubleRoomPrice = 170,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 6,
                Title = "АТИЯ РЕЗОРТ",
                LocationId = 2,
                Description = "Аполония резорт е луксозен, апартаментен комплекс от затворен тип, състоящ се от две четири етажни сгради с капацитет от 23 апартамента. Апартаментите са от различен тип, напълно оборудвани с всичко необходимо за престоя на своите гости. Намира се в района на живописното черноморско градче Черноморец, на 400 м от центъра и на 300 м от златистия плаж. Хотелът разполага със собствен ресторант, където гостите ползват отстъпка.",
                CategoryId = 3,
                CateringTypeId = 4,
                Star = 4,
                DoubleRoomPrice = 200,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 7,
                Title = "ВИЛА ДАРИ",
                LocationId = 1,
                Description = "Къща за гости Дари се намира в новата част на античния град Созопол. Тя е разположена между два плажа на разстояние 5 - 6 минути от всеки плаж. Къщата се намира на тиха и спокойна улица, която дава възможност на туристите за пълноценна почивка. Къщата за гости разполага със самостоятелни стаи и апартаменти. Всички помещения са с тераса, санитарен възел, телевизор, хладилник, климатик и безплатен интернет.",
                CategoryId = 1,
                CateringTypeId = 1,
                Star = 3,
                DoubleRoomPrice = 100,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 8,
                Title = "ХОРИЗОНТ",
                LocationId = 1,
                Description = "Разположен върху живописни скали на морския бряг в новата част на града, хотел „Фиорд” е идеален за мечтаната почивка. Плаж „Хармани” се намира на 60м. Хотелът разполага с еднакво обзаведени Двойни стаи от различен тип, различаващи се по площта си.",
                CategoryId = 1,
                CateringTypeId = 3,
                Star = 3,
                DoubleRoomPrice = 160,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

            hotel = new Hotel()
            {
                Id = 9,
                Title = "ФИОРД",
                LocationId = 1,
                Description = "Разположен върху живописни скали на морския бряг в новата част на града, хотел „Фиорд” е идеален за мечтаната почивка. Плаж „Хармани” се намира на 60м. Хотелът разполага с еднакво обзаведени Двойни стаи от различен тип, различаващи се по площта си.",
                CategoryId = 1,
                CateringTypeId = 3,
                Star = 3,
                DoubleRoomPrice = 130,
                AgentId = Guid.Parse("0174683e-a3fd-4f3c-a2b7-3c3792dad867"),
                IsActive = true
            };

            hotels.Add(hotel);

           


            return hotels.ToArray();
        }
    }
}
