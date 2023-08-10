namespace TravelAgency.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Data.Interfaces;
    using Data;
    using static DatabaseSeeder;


    public class ImageServiceTest
    {
        private DbContextOptions<TravelAgencyDbContext> dbOptions;
        private TravelAgencyDbContext dbContext;

        private IImageService imageService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase("TravelAgencyInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TravelAgencyDbContext(this.dbOptions);

            dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.imageService = new ImageService(this.dbContext);
        }



        //[Test]
        //public async Task AddImagesAsync_ShouldAddImagesToHotel()
        //{
        //    int hotelId = Hotel.Id; 

        //    var imageUrls = new List<string>
        //    {
        //        "image1.jpg",
        //        "image2.jpg",
        //        "image3.jpg"
        //    };
            
        //    await imageService.AddImagesAsync(imageUrls, hotelId);
            
        //    Assert.AreEqual(imageUrls.Count, Hotel.Images.Count); 
        //}

    }
}
