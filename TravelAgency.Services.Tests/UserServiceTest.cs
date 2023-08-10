namespace TravelAgency.Services.Tests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Web.ViewModels.User;
    using static DatabaseSeeder;

    public class UserServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;
        
        private IUserService userService;
        
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
        

        [Test]
        public async Task GetFullNameByEmailAsync()
        {
            
            string userFullName = User.FirstName + " " + User.LastName;
            
            string userEmail = User.Email;

            string result = await this.userService.GetFullNameByEmailAsync(userEmail);

            Assert.AreEqual(userFullName, result);
        }

        [Test]
        public async Task GetFullNameByIdAsync()
        {
            string userId = "6D5800CE-D726-4FC8-83D9-D6B3AC1F591E";

            string userFullName = "Georgi Georgiev";

            string result = await this.userService.GetFullNameByIdAsync(userId);
            
            Assert.AreEqual(userFullName, result);
        }

        [Test]
        public async Task AllUserAsync()
        {
            IEnumerable<UserViewModel> result = await this.userService.AllUserAsync();

            int count = result.Count();

            Assert.AreEqual(2, count);
        }

        [Test]
        public async Task AllUserReservationAsync()
        {
            string userId = Guid.Parse("6D5800CE-D726-4FC8-83D9-D6B3AC1F591E").ToString();

            var allReservations = await this.userService.AllUserReservationAsync(userId);

            int count = allReservations.Count();

            Assert.AreEqual(0, count);
        }
    }
}