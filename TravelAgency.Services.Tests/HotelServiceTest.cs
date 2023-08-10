namespace TravelAgency.Services.Tests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Web.ViewModels.Hotel;
    using Web.ViewModels.Hotel.Enums;
    using static DatabaseSeeder;


    public class HotelServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private IHotelService hotelService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.hotelService = new HotelService(this.dbContext);

        }

        
        [Test]
        public async Task LastThreeAddedHotelAsync()
        {
            var lastThreeHotels = await this.hotelService.LastThreeAddedHotelAsync();

            int count = lastThreeHotels.Count();

            Assert.That(count, Is.EqualTo(3));
        }


        [Test]
        public async Task GetHotelDetailsByAdAsync_ShouldReturnCorrectViewModel()
        {
            int hotelId = 1;

            var viewModel = await hotelService.GetHotelDetailsByAdAsync(hotelId);

            Assert.NotNull(viewModel);
            Assert.AreEqual(hotelId, viewModel.Id);
            Assert.NotNull(viewModel.Title);
            Assert.NotNull(viewModel.Posts);
            Assert.NotNull(viewModel.Posts.Count());
            Assert.NotNull(viewModel.Images);
            Assert.NotNull(viewModel.Images.Count());
        }

        [Test]
        public async Task AllWishHotelByUserAsync()
        {
            int hotelId = 1;

            bool hotelExist = await hotelService.HotelExistByIdAsync(hotelId);

            Assert.True(hotelExist);
        }

        [Test]
        public async Task AllHotelAsync_ShouldReturnFilteredAndPagedHotels()
        {
            var queryModel = new AllHotelQueryModel
            {
                Category = "Семеен хотел",
                HotelSorting = HotelSorting.Newest
            };

            var options = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyTestDb")
                .Options;

            var result = await hotelService.AllHotelAsync(queryModel);

            Assert.NotNull(result);
        }

        [Test]
        public async Task AllWishHotelByUserAsync_ShouldReturnWishListedHotelsByUserId()
        {
            var userId = "949A14ED-2E82-4F5A-A684-A9C7E3CCB52E"; // Replace with a valid user id for your test scenario

            var hotelService = new HotelService(dbContext);

            var result = await hotelService.AllWishHotelByUserAsync(userId);

            Assert.NotNull(result);
        }

        //[Test]
        //public async Task GetHotelForEditByIdAsync_ShouldReturnHotelFormModelById()
        //{
        //    int hotelId = 1; 

        //    HotelFormModel result = await hotelService.GetHotelForEditByIdAsync(hotelId);
            
        //    Assert.NotNull(result);
        //    Assert.AreEqual(result.Title, "ЛАГУНА БИЙЧ");
        //}

        //[Test]
        //public async Task EditHotelByIdAndFormModelAsync_ShouldUpdateHotelWithCorrectData()
        //{
        //    // Arrange
        //    int hotelId = 1; // Provide a valid hotel id based on your test data
        //    var model = new HotelFormModel
        //    {
        //        Title = "New Title",
        //        Location = "New Location",
        //        Star = 4,
        //        CategoryId = 2,
        //        CateringTypeId = 1,
        //        Description = "New Description",
        //        Images = new List<string>
        //{
        //    "new_image1.jpg",
        //    "new_image2.jpg"
        //},
        //        DoubleRoomPrice = 150,
        //        StudioPrice = 200,
        //        IsActive = true
        //    };

        //    // Act
        //    await hotelService.EditHotelByIdAndFormModelAsync(hotelId, model);

        //    // Assert
            
        //    // Assert.NotNull(editedHotel); // Ensure the hotel was found
        //}


    }
}
