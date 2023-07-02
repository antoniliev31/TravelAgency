namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class HouseEntityConfigurations : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValue(DateTime.Now);
            
            builder
                .HasOne(h => h.Category)
                .WithMany(c => c.Houses)
                .HasForeignKey(h => h.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.Agent)
                .WithMany(a => a.OwnedHouses)
                .HasForeignKey(h => h.AgentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(h => h.City)
                .WithMany(c => c.HosesInCity)
                .HasForeignKey(h => h.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GenerateHouses());
        }

        private House[] GenerateHouses()
        {
            ICollection<House> houses = new HashSet<House>();

            House house;
            house = new House()
            {
                Title = "Morska zvezda",
                Address = "Lozengrad 15",
                CityId = 1,
                Description = "Малък семеен хотел в новата част на Созопол. намира се събсем близо до плажа.",
                CategoryId = 1,
                AgentId = Guid.Parse("951BD3FF-53E2-49C4-A272-19D7EC7CFB14"),
                ImageUrl = "https://scontent.fsof1-1.fna.fbcdn.net/v/t1.6435-9/100680496_278314133535432_5456391328319406080_n.jpg?_nc_cat=111&cb=99be929b-3346023f&ccb=1-7&_nc_sid=730e14&_nc_ohc=RQpXwJhHdZ8AX_Zk1Ij&_nc_ht=scontent.fsof1-1.fna&oh=00_AfBao85ltJ0fFXEO_3zyFBC7IudFxDoxuQfOT-3Lzt8mtg&oe=64C4CE8C"
            };

            houses.Add(house);

            house = new House()
            {
                Title = "Tabanov Beach",
                Address = "Republikanska 37",
                CityId = 1,
                Description = "Хотел „Табанов бийч” е разположен в новата част на град Созопол. Намира се само на 60м. от плаж \"Хармани\", а в близост има много магазини, ресторанти, клубове и други развлечения..",
                CategoryId = 1,
                AgentId = Guid.Parse("951BD3FF-53E2-49C4-A272-19D7EC7CFB14"),
                ImageUrl = "http://www.tabanovhotel.com/images/slide1.jpg"
            };

            houses.Add(house);

            return houses.ToArray();
        }
    }
}
