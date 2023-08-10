namespace TravelAgency.Services.Tests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using static DatabaseSeeder;

    public class CategoryServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private ICategoryService categoryService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task AllCategoryesAsync()
        {
            var allCategories = categoryService.AllCategoryesAsync();

            Assert.NotNull(allCategories);
        }

        [Test]
        public async Task ExistByIdAsync()
        {
            int categoryId = 1;
            
            bool isExist = await categoryService.ExistByIdAsync(categoryId);

            Assert.True(isExist);
        }

        [Test]
        public async Task AllCategoryNamesAsync()
        {
            var allCategoryNames = await categoryService.AllCategoryNamesAsync();

            Assert.NotNull(allCategoryNames);
        }
    }
}
