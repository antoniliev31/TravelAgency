namespace TravelAgency.Services.Tests
{
    using System.Collections;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Data;
    using TravelAgency.Data.Models;


    [TestFixture]
    public class ImageServiceTest
    {
        private TravelAgencyDbContext context;
        private ImageService imageService;

        private string userId = "949A14ED-2E82-4F5A-A684-A9C7E3CCB52E";

        [SetUp]
        public async Task SetUp()
        {
            List<Hotel> hotels = new()
            {
                new Hotel
                {
                    Id = 1,
                    Title = "TestHotel1",
                    Description = "",
                    Star = 1,
                    CreatedOn = new DateTime(2023, 1, 1),
                    DoubleRoomPrice = 1,
                    StudioRoomPrice = 2,
                    ApartmentRoomPrice = 3,
                    IsActive = true,
                    LocationId = 1,
                    CategoryId = 1,
                    CateringTypeId = 1
                },
                new Hotel
                {
                    Id = 2,
                    Title = "TestHotel2",
                    Description = "",
                    Star = 1,
                    CreatedOn = new DateTime(2023, 2, 2),
                    DoubleRoomPrice = 1,
                    StudioRoomPrice = 2,
                    ApartmentRoomPrice = 3,
                    IsActive = true,
                    LocationId = 2,
                    CategoryId = 2,
                    CateringTypeId = 2
                },
                new Hotel
                {
                    Id = 3,
                    Title = "TestHotel3",
                    Description = "",
                    Star = 1,
                    CreatedOn = new DateTime(2023, 3, 3),
                    DoubleRoomPrice = 1,
                    StudioRoomPrice = 2,
                    ApartmentRoomPrice = 3,
                    IsActive = true,
                    LocationId = 3,
                    CategoryId = 3,
                    CateringTypeId = 3
                },
            };

            List<Category> categories = new()
            {
                new Category
                {
                    Id = 1,
                    Name = "TestCategory1"
                },
                new Category
                {
                    Id = 2,
                    Name = "TestCategory2"
                },
                new Category
                {
                    Id = 3,
                    Name = "TestCategory3"
                },
            };

            List<Location> locations = new()
            {
                new Location
                {
                    Id = 1,
                    Name = "TestCity1"
                },
                new Location
                {
                    Id = 2,
                    Name = "TestCity2"
                },
                new Location
                {
                    Id = 3,
                    Name = "TestCity3"
                }
            };

            List<CateringType> caterings = new()
            {
                new CateringType
                {
                    Id = 1,
                    Name = "TestCateringType1"
                },
                new CateringType
                {
                    Id = 2,
                    Name = "TestCateringType1"
                },
                new CateringType
                {
                    Id = 3,
                    Name = "TestCateringType1"
                }
            };

            List<Post> posts = new()
            {
                new Post
                {
                    Id = 1,
                    Content = "TestContent1",
                    UserId = Guid.Parse(userId),
                    HotelId = 1,
                },
                new Post
                {
                    Id = 2,
                    Content = "TestContent2",
                    UserId = Guid.Parse(userId),
                    HotelId = 2,
                },
                new Post
                {
                    Id = 3,
                    Content = "TestContent3",
                    UserId = Guid.Parse(userId),
                    HotelId = 3,
                }
            };

            List<Image> images = new()
            {
                new Image
                {
                    Id = 1,
                    ImageUrl = "www.test1.com",
                    IsMain = true,
                    HotelId = 1
                },
                new Image
                {
                    Id = 2,
                    ImageUrl = "www.test2.com",
                    IsMain = false,
                    HotelId = 1
                },
                new Image
                {
                    Id = 3,
                    ImageUrl = "www.test3.com",
                    IsMain = false,
                    HotelId = 1
                },
            };

            List<WishList> wishLists = new()
            {
                new WishList
                {
                    Id = 1,
                    UserId = Guid.Parse(userId),
                    HotelId = 1,
                },
                new WishList
                {
                    Id = 2,
                    UserId = Guid.Parse(userId),
                    HotelId = 2,
                },
                new WishList
                {
                    Id = 3,
                    UserId = Guid.Parse(userId),
                    HotelId = 3,
                },
            };

            List<ApplicationUser> users = new()
            {
                new ApplicationUser
                {
                    Id = Guid.Parse(userId),
                    UserName = "test@test.com",
                    NormalizedUserName = "TEST@TEST.COM",
                    Email = "test@test.com",
                    NormalizedEmail = "TEST@TEST.COM",
                    EmailConfirmed = true,
                    PasswordHash =
                        "AQAAAAEAACcQAAAAEHmiB5uR1oqD9I2hfuUggkf2QC4GYTpvzI4iqY7pqZfLT+cmafn6btCBoSsDTCZX6g==",
                    SecurityStamp = "d6cd7a62-b808-4f84-9da3-e24b9be6edfb",
                    ConcurrencyStamp = "9d289e8b-75c6-485c-9fed-0de2511d9ee4",
                    PhoneNumber = "0777888999",
                    FirstName = "Test",
                    LastName = "Test"
                }
            };

            var options = new DbContextOptionsBuilder<TravelAgencyDbContext>()
                .UseInMemoryDatabase(databaseName: "PBSystemInMemory")
                .Options;
            context = new TravelAgencyDbContext(options);

            await context.Database.EnsureDeletedAsync();

            await context.Hotels.AddRangeAsync(hotels);
            await context.Categories.AddRangeAsync(categories);
            await context.Locations.AddRangeAsync(locations);
            await context.CateringTypes.AddRangeAsync(caterings);
            await context.Posts.AddRangeAsync(posts);
            await context.Images.AddRangeAsync(images);
            await context.WishLists.AddRangeAsync(wishLists);
            await context.ApplicationUsers.AddRangeAsync(users);

            await context.SaveChangesAsync();

            imageService = new ImageService(context);
        }

        [Test]
        public async Task AddImagesAsync_ShouldAddImagesToHotel()
        {
            int hotelId = 1;
            var imageUrls = new List<string>
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            await imageService.AddImagesAsync(imageUrls, hotelId);

            var hotelWithImages = await context.Hotels
                .Include(h => h.Images)
                .FirstOrDefaultAsync(h => h.Id == hotelId);

            Assert.NotNull(hotelWithImages);
            
        }

    }
}
