namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasData(GenerateCity());
        }

        private City[] GenerateCity()
        {
            ICollection<City> cities = new HashSet<City>();

            City city;
            city = new City()
            {
                Id = 1,
                Name = "Sozopol"
            };

            cities.Add(city);

            city = new City()
            {
                Id = 2,
                Name = "Primorsko"
            };

            cities.Add(city);

            city = new City()
            {
                Id = 3,
                Name = "Kiten"
            };

            cities.Add(city);

            return cities.ToArray();
        }
    }
}
