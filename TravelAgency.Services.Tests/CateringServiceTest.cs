namespace TravelAgency.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Data.Interfaces;
    using Data;
    using static DatabaseSeeder;

    public class CateringServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private ICateringService cateringService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.cateringService = new CateringService(this.dbContext);
        }

        [Test]
        public async Task AllCateringTypesAsync()
        {
            var allCateringTypes = cateringService.AllCateringTypesAsync();

            Assert.NotNull(allCateringTypes);
        }

        [Test]
        public async Task ExistByIdAsync()
        {
            int categoryId = 1;

            bool isExist = await cateringService.ExistByIdAsync(categoryId);

            Assert.True(isExist);
        }
    }
}
