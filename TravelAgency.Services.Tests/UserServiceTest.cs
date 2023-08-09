namespace TravelAgency.Services.Tests
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;

    using static DatabaseSeeder;

    public class UserServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;
        private UserService userService;
        

        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.userService = new UserService(this.dbContext);
        }

        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetFullNameByEmailAsync()
        {
            string userFullName = User.FirstName + " " + User.LastName;
            
            string userEmail = User.Email;

            string result = await this.userService.GetFullNameByEmailAsync(userEmail);

            Assert.AreEqual(userFullName, result);
        }
    }
}