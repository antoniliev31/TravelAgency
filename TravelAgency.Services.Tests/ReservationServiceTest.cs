namespace TravelAgency.Services.Tests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using static DatabaseSeeder;

    public class ReservationServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private IReservationService reservationService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.reservationService = new ReservationService(this.dbContext);
        }

        [Test]
        public async Task AllAsync()
        {
            var allReservations = await reservationService.AllAsync();

            Assert.NotNull(allReservations);
        }
    }
}
