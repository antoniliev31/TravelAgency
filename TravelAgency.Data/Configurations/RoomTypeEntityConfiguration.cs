namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    

    public class RoomTypeEntityConfiguration : IEntityTypeConfiguration<RoomType>
    {
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private RoomType[] GenerateCategories()
        {
            ICollection<RoomType> categories = new HashSet<RoomType>();

            RoomType typeOfHotel;
            typeOfHotel = new RoomType()
            {
                Id = 1,
                Name = "Double room"
            };

            categories.Add(typeOfHotel);

            typeOfHotel = new RoomType()
            {
                Id = 2,
                Name = "Studio"
            };

            categories.Add(typeOfHotel);

            typeOfHotel = new RoomType()
            {
                Id = 3,
                Name = "Apartment"
            };

            categories.Add(typeOfHotel);

            return categories.ToArray();
        }
    }
}
