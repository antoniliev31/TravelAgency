namespace TravelAgency.Services.Tests
{
    using Data;
    using Data.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using Web.ViewModels.Hotel;
    using Web.ViewModels.Hotel.Enums;
    using static DatabaseSeeder;

    [TestFixture]
    public class HotelServiceTest
    {
        private TravelAgencyDbContext context;
        private IHotelService hotelService;
        private ICategoryService categoryService;
        private ILocationService locationService;
        private ICateringService cateringService;
        private IPostService postService;
        private IImageService imageService;
        private IWishService wishService;

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

            hotelService = new HotelService(context);
            //categoryService = new CategoryService(context);
            //locationService = new LocationService(context);
            //cateringService = new CateringService(context);
            //postService = new PostService(context);
            //imageService = new ImageService(context);
            //wishService = new WishService(context);

        }


        [Test]
        public async Task LastThreeAddedHotelAsync()
        {
            var result = await hotelService.LastThreeAddedHotelAsync();

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task GetHotelDetailsByAdAsync_ShouldReturnCorrectViewModel()
        {
            int hotelId = 2;

            var result = await hotelService.GetHotelDetailsByAdAsync(hotelId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task TaskCreateHotelAndReturnIdAsync()
        {
            HotelFormModel model = new HotelFormModel
            {
                Title = "NewHotel",
                Location = "TestNewLocation",
                Star = 1,
                CategoryId = 1,
                CateringTypeId = 1,
                Description = "TestDescription",
                Images = new List<string>(),
                DoubleRoomPrice = 1,
                StudioPrice = 2,
                ApartmentPrice = 3,
                IsActive = true
            };

            var result = hotelService.CreateHotelAndReturnIdAsync(model, 1);
            var hotelId = result.Id;
            Assert.AreEqual(hotelId, 1);
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
                Category = "",
                HotelSorting = HotelSorting.Newest
            };

            var result = await hotelService.AllHotelAsync(queryModel);

            Assert.NotNull(result);
        }

        [Test]
        public async Task AllWishHotelByUserAsync_ShouldReturnWishListedHotelsByUserId()
        {
            var userId = "949A14ED-2E82-4F5A-A684-A9C7E3CCB52E"; // Replace with a valid user id for your test scenario

            var hotelService = new HotelService(context);

            var result = await hotelService.AllWishHotelByUserAsync(userId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task GetHotelForEditByIdAsync_ShouldReturnHotelFormModelById()
        {
            int hotelId = 1;

            var result = await hotelService.GetHotelForEditByIdAsync(hotelId);

            Assert.NotNull(result);
            Assert.AreEqual(result.Title, "TestHotel1");
        }

        [Test]
        public async Task GetHotelDetailsByAdAsync()
        {
            int hotelId = 1;

            var result = await hotelService.GetHotelDetailsByAdAsync(hotelId);

            Assert.NotNull(result);
            Assert.AreEqual(result.Title, "TestHotel1");
        }

        [Test]
        public async Task GetHotelForDeleteByIdAsync()
        {
            int hotelId = 1;

            var result = await hotelService.GetHotelForDeleteByIdAsync(hotelId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task DeleteHotelByIdAsync_ShouldDeleteHotel()
        {
            // Подгответе данни за теста
            HotelFormModel model = new HotelFormModel
            {
                Title = "NewHotel",
                Location = "TestNewLocation",
                Star = 1,
                CategoryId = 1,
                CateringTypeId = 1,
                Description = "TestDescription",
                Images = new List<string>(),
                DoubleRoomPrice = 1,
                StudioPrice = 2,
                ApartmentPrice = 3,
                IsActive = true
            };

            var createResult = await hotelService.CreateHotelAndReturnIdAsync(model, 1);
            var hotelId = createResult; // createResult е вече идентификаторът на създадения хотел

            await hotelService.DeleteHotelByIdAsync(hotelId);
            
            var isDeleted = await context.Hotels
                .Where(h => h.Id == hotelId && !h.IsActive) // Проверете дали хотелът съществува и не е активен
                .AnyAsync();

           Assert.True(isDeleted);
        }

        [Test]
        public async Task GetHotelForReservationByAdAsync_ShouldReturnCorrectViewModel()
        {
            var hotelId = 1; 

            var result = await hotelService.GetHotelForReservationByAdAsync(hotelId);

            Assert.NotNull(result); 

            Assert.AreEqual(hotelId, result.Id);
            Assert.NotNull(result.Title);
            Assert.NotNull(result.Location);
            Assert.NotNull(result.ImageUrl);
            Assert.NotNull(result.Category);
            Assert.NotNull(result.CateringType);
            Assert.NotNull(result.RoomTypes);
            Assert.True(result.Star > 0);
            Assert.True(result.DoubleRoomPrice > 0);
            Assert.True(result.StudioPrice > 0);
            Assert.True(result.ApartmentPrice > 0);

            
            Assert.AreEqual(DateTime.Today, result.AccommodationDate.Date);
            Assert.AreEqual(DateTime.Today, result.DepartureDate.Date);
        }

    }
}