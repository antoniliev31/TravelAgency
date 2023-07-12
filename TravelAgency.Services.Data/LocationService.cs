namespace TravelAgency.Services.Data
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;

    using Web.ViewModels.Hotel;


    public class LocationService : ILocationService
    {
        private readonly TravelAgencyDbContext dbContext;

        public LocationService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> LocationExistByNameAsync(string locationName)
        {
            bool result = await this.dbContext
                .Locations
                .AnyAsync(c => c.Name == locationName);

            return result;
        }

        public async Task CreateLocationAsync(string locationName)
        {
            Location newLocation = new Location()
            {
                Name = locationName

            };

            await this.dbContext.Locations.AddAsync(newLocation);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> GetLocationId(string cityName)
        {
            Location location = await this.dbContext
                .Locations
                .FirstAsync(c => c.Name == cityName);

            return location.Id;
        }

        public async Task<IEnumerable<string>> AllLocationNamesAsync()
        {
            IEnumerable<string> allLocationNames = await this.dbContext
                .Locations
                .Select(c => c.Name)
                .ToArrayAsync();

            return allLocationNames;
        }
    }
}
