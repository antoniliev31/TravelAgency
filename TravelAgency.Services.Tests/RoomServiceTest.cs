namespace TravelAgency.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Services.Data.Interfaces;
    using TravelAgency.Services.Data;
    using static DatabaseSeeder;

    public class RoomServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private IRoomService roomService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.roomService = new RoomService(this.dbContext);
        }

        [Test]
        public async Task AllRoomTypeAsync()
        {
            var allRoomTypes = await roomService.AllRoomTypeAsync();

            Assert.NotZero(allRoomTypes.Count());
        }

        [Test]
        public async Task ExistByIdAsync()
        {
            bool isExist = await roomService.ExistByIdAsync(1);

            Assert.True(isExist);
        }


    }
}
