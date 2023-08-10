namespace TravelAgency.Services.Tests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using static DatabaseSeeder;

    public class WishServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private IWishService wishService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.wishService = new WishService(this.dbContext);
        }

        [Test]
        public async Task AddHotelToWishListAsync()
        {
            int hotelId = 1;
            string userId = Guid.NewGuid().ToString();

            var result = this.wishService.AddHotelToWishListAsync(hotelId, userId);
        }
    }
}
