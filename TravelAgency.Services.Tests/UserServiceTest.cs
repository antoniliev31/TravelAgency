namespace TravelAgency.Services.Tests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using Web.ViewModels.User;
    using Xunit;

    [TestFixture]
    public class UserServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;
        
        private IUserService userService;
        private readonly string testUserId = "949A14ED-2E82-4F5A-A684-A9C7E3CCB52E";
        private readonly string testUserFullName = "Test Test";
        private readonly string username = "test@test.com";
        private readonly string email = "test@test.com";
        private readonly string firstName = "Test";
        private readonly string lastName = "Test";

        [SetUp]
        public async Task Setup()
        {
            var user = new ApplicationUser
            {
                Id = Guid.Parse(testUserId),
                UserName = username,
                NormalizedUserName = "TEST@TEST.COM",
                Email = email,
                NormalizedEmail = "TEST@TEST.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEHmiB5uR1oqD9I2hfuUggkf2QC4GYTpvzI4iqY7pqZfLT+cmafn6btCBoSsDTCZX6g==",
                SecurityStamp = "d6cd7a62-b808-4f84-9da3-e24b9be6edfb",
                ConcurrencyStamp = "9d289e8b-75c6-485c-9fed-0de2511d9ee4",
                PhoneNumber = "+359888888888",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                FirstName = firstName,
                LastName = lastName,
                MyWishLists = null,
                MyOrders = null,
                MyPosts = null
            };

            var options = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase(databaseName: "TravelAgencyInMemory")
                .Options;
            dbContext = new TravelAgencyDbContext(options);

            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.Users.AddAsync(user);

            var count = dbContext.Users.Count();
            
            await dbContext.SaveChangesAsync();

            userService = new UserService(this.dbContext);

        }
        

        [Test]
        public async Task GetFullNameByEmailAsync()
        {
            string userFullName = testUserFullName;
            string userEmail = email;

            string result = await this.userService.GetFullNameByEmailAsync(userEmail);

            Assert.Equal(testUserFullName, result);
        }

        [Test]
        public async Task GetFullNameByIdAsync()
        {
            string userId = testUserId;

            string userFullName = testUserFullName;

            string result = await this.userService.GetFullNameByIdAsync(userId);
            
            Assert.Equal(userFullName, result);
        }

        [Test]
        public async Task AllUserAsync()
        {
            IEnumerable<UserViewModel> result = await this.userService.AllUserAsync();

            int count = result.Count();

            Assert.Equal(1, count);
        }

        [Test]
        public async Task AllUserReservationAsync()
        {
            string userId = testUserId;

            var allReservations = await this.userService.AllUserReservationAsync(userId);

            int count = allReservations.Count();

            Assert.Equal(0, count);
        }
    }
}