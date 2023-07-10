namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    using Models;

    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(GenerateCity());
        }

        private Location[] GenerateCity()
        {
            ICollection<Location> locations = new HashSet<Location>();

            Location location;
            location = new Location()
            {
                Id = 1,
                Name = "Созопол"
            };

            locations.Add(location);

            location = new Location()
            {
                Id = 2,
                Name = "Черноморец"
            };

            locations.Add(location);

            location = new Location()
            {
                Id = 3,
                Name = "Дюни"
            };

            locations.Add(location);

            location = new Location()
            {
                Id = 4,
                Name = "Слънчев бряг"
            };

            locations.Add(location);

            location = new Location()
            {
                Id = 5,
                Name = "Златни пясъци"
            };

            locations.Add(location);

            return locations.ToArray();
        }
    }
}
