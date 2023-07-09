namespace TravelAgency.Services.Data
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;

    using TravelAgency.Web.ViewModels.House;


    public class CityService : ICityService
    {
        private readonly TravelAgencyDbContext dbContext;

        public CityService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CityExistByNameAsync(string cityName)
        {
            bool result = await this.dbContext
                .Cities
                .AnyAsync(c => c.Name == cityName);

            return result;
        }

        public async Task CreateCityAsync(string cityName)
        {
            City newCity = new City()
            {
                Name = cityName

            };

            await this.dbContext.Cities.AddAsync(newCity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<int> GetCityId(string cityName)
        {
            City city = await this.dbContext
                .Cities
                .FirstAsync(c => c.Name == cityName);

            return city.Id;
        }

        public async Task<IEnumerable<string>> AllCityNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Cities
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }
    }
}
