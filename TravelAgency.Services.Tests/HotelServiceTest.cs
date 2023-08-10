namespace TravelAgency.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    
    using static DatabaseSeeder;

    
    public class HotelServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;
        

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);
            
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task LastThreeAddedHotelAsync()
        {
            //var lastThreeHotels = await this.hotelService.LastThreeAddedHotelAsync();

            //int count = lastThreeHotels.Count();

            //Assert.That(count, Is.EqualTo(3));
        }
    }
}
