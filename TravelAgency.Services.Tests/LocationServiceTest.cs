namespace TravelAgency.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Data.Interfaces;
    using Data;
    using static DatabaseSeeder;

    public class LocationServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private ILocationService locationService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.locationService = new LocationService(this.dbContext);
        }

        [Test]
        public async Task LocationExistByNameAsync()
        {
            var isExist = await locationService.LocationExistByNameAsync("Созопол");

            Assert.IsTrue(isExist);
        }

        [Test]
        public async Task GetLocationId()
        {
            int locationId = await locationService.GetLocationId("Созопол");

            Assert.NotZero(locationId);
        }

        [Test]
        public async Task AllLocationNamesAsync()
        {
            var allLocations = await locationService.AllLocationNamesAsync();

            Assert.NotZero(allLocations.Count());
        }


    }
}
