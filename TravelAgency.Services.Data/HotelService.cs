namespace TravelAgency.Services.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using TravelAgency.Data;
    using Web.ViewModels.Hotel;
    using Interfaces;
    using Web.ViewModels.Home;
    using Models.House;
    using TravelAgency.Data.Models;
    using Web.ViewModels.Hotel.Enums;
    using Web.ViewModels.Image;
    using Web.ViewModels.Post;

    using static Common.EntityValidationConstants;
    using Hotel = TravelAgency.Data.Models.Hotel;
    using Image = TravelAgency.Data.Models.Image;

    public class HotelService : IHotelService
    {
        private readonly TravelAgencyDbContext dbContext;

        public HotelService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeAddedHotelAsync()
        {
            var lastThreeHotel = await this.dbContext
                .Hotels
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(h => new IndexViewModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? h.Images.FirstOrDefault()!.ImageUrl
                })
                .ToListAsync();


            Random random = new Random();
            foreach (var hotel in lastThreeHotel)
            {
                var posts = await this.dbContext.Posts
                    .Where(p => p.HotelId == hotel.Id)
                    .ToListAsync();

                if (posts.Count > 0)
                {
                    int randomIndex = random.Next(0, posts.Count);
                    hotel.Text = posts[randomIndex].Content;
                }
            }

            return lastThreeHotel;
        }

        public async Task<int> CreateHotelAndReturnIdAsync(HotelFormModel formModel, int locationId)
        {
            Hotel newHotel = new Hotel
            {
                Title = formModel.Title,
                LocationId = locationId,
                Description = formModel.Description,
                CategoryId = formModel.CategoryId,
                CateringTypeId = formModel.CateringTypeId,
                Star = formModel.Star,
                DoubleRoomPrice = formModel.DoubleRoomPrice,
                StudioRoomPrice = formModel.StudioPrice,
                ApartmentRoomPrice = formModel.ApartmentPrice,
                IsActive = true
            };

            await this.dbContext.Hotels.AddAsync(newHotel);
            await this.dbContext.SaveChangesAsync();

            return newHotel.Id;
        }

        public async Task<AllHotelsFilteredAndPagesServiceModel> AllHotelAsync(AllHotelQueryModel queryModel)
        {
            IQueryable<Hotel> hotelsQuery = this.dbContext
                .Hotels
                .Where(h => h.IsActive)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                hotelsQuery = hotelsQuery
                    .Where(h => h.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                hotelsQuery = hotelsQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                                EF.Functions.Like(h.Location.Name, wildCard) ||
                                EF.Functions.Like(h.Description, wildCard));
            }

            if (!string.IsNullOrWhiteSpace(queryModel.Location))
            {
                hotelsQuery = hotelsQuery
                    .Where(h => h.Location.Name == queryModel.Location);
            }

            if (queryModel.Star == 2 || queryModel.Star == 3 || queryModel.Star == 4 || queryModel.Star == 5)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Star == queryModel.Star);
            }

            hotelsQuery = queryModel.HotelSorting switch
            {
                HotelSorting.Newest => hotelsQuery
                    .OrderByDescending(h => h.CreatedOn),
                HotelSorting.Oldest => hotelsQuery
                    .OrderBy(h => h.CreatedOn),
                HotelSorting.CityAscending => hotelsQuery
                    .OrderBy(h => h.Location),
                HotelSorting.CityDescending => hotelsQuery
                    .OrderByDescending(h => h.Location),
                HotelSorting.PriceAscending => hotelsQuery
                    .OrderBy(h => h.DoubleRoomPrice),
                HotelSorting.PriceDescending => hotelsQuery
                    .OrderByDescending(h => h.DoubleRoomPrice),
                _ => hotelsQuery
                    .OrderByDescending(h => h.DoubleRoomPrice)
            };

            IEnumerable<HotelAllViewModel> allHotels = await hotelsQuery
                .Where(h => h.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.HotelsPerPage)
                .Take(queryModel.HotelsPerPage)
                .Select(h => new HotelAllViewModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    Location = h.Location.Name,
                    Star = h.Star,
                    Catering = h.CateringType.Name,
                    ImageUrl = h.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                    DoubleRoomPrice = h.DoubleRoomPrice,
                    StudioPrice = h.StudioRoomPrice,
                    ApartmentPrice = h.ApartmentRoomPrice
                })
                .ToArrayAsync();

            int totalHouses = hotelsQuery.Count();

            return new AllHotelsFilteredAndPagesServiceModel
            {
                TotalHotelsCount = totalHouses,
                Hotels = allHotels
            };
        }

        public async Task<IEnumerable<HotelAllViewModel>> AllWishHotelByUserAsync(string userId)
        {
            IEnumerable<HotelAllViewModel> allWishHotelByAgent = await this.dbContext
                .WishLists
                .Where(h => h.Hotel.IsActive)
                .Where(h => h.UserId == Guid.Parse(userId))
                .Select(h => new HotelAllViewModel
                {
                    Id = h.Hotel.Id,
                    Title = h.Hotel.Title,
                    Location = h.Hotel.Location.Name,
                    Catering = h.Hotel.CateringType.Name,
                    Category = h.Hotel.Category.Name,
                    ImageUrl = h.Hotel.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                    DoubleRoomPrice = h.Hotel.DoubleRoomPrice,
                    StudioPrice = h.Hotel.StudioRoomPrice,
                    ApartmentPrice = h.Hotel.ApartmentRoomPrice,
                    Star = h.Hotel.Star,
                })
                .ToArrayAsync();

            return allWishHotelByAgent;
        }

        public async Task<IEnumerable<HotelAllViewModel>> AllOrderHotelByUserAsync(string userId)
        {
            IEnumerable<HotelAllViewModel> allOrderByUser = await this.dbContext
                .Orders
                .Where(h => h.Hotel.IsActive)
                .Where(h => h.UserId == Guid.Parse(userId))
                .Select(h => new HotelAllViewModel
                {
                    Id = h.Hotel.Id,
                    Title = h.Hotel.Title,
                    Location = h.Hotel.Location.Name,
                    Catering = h.Hotel.CateringType.Name,
                    Category = h.Hotel.Category.Name,
                    ImageUrl = h.Hotel.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                    DoubleRoomPrice = h.Hotel.DoubleRoomPrice,
                    StudioPrice = h.Hotel.StudioRoomPrice,
                    ApartmentPrice = h.Hotel.ApartmentRoomPrice,
                    Star = h.Hotel.Star
                })
                .ToArrayAsync();

            return allOrderByUser;
        }

        public async Task<HotelDetailsViewModel?> GetHotelDetailsByAdAsync(int id)
        {
            Hotel hotel = await this.dbContext
                .Hotels
                .Include(h => h.Category)
                .Include(h => h.Location)
                .Include(h => h.CateringType)
                //.ThenInclude(a => a.User)
                .Include(h => h.Posts)
                .Include(h => h.Images)
                .Include(h => h.WishLists)
                .FirstAsync(h => h.IsActive && h.Id == id);


            List<PostViewModel> posts = new List<PostViewModel>();

            foreach (var post in hotel.Posts)
            {
                var user = await this.dbContext.Users.FindAsync(post.UserId);
                var userName = user?.UserName ?? string.Empty;

                PostViewModel p = new PostViewModel
                {
                    Id = post.Id,
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                    UserName = userName,
                    Description = post.Content
                };
                posts.Add(p);
            }

            List<ImageViewModel> images = new List<ImageViewModel>();
            foreach (var image in hotel.Images)
            {
                ImageViewModel im = new ImageViewModel()
                {
                    Id = image.Id,
                    ImageUrl = image.ImageUrl,
                    IsMain = image.IsMain
                };

                images.Add(im);
            }

            var viewModel = new HotelDetailsViewModel
            {
                Id = hotel.Id,
                Title = hotel.Title,
                Location = hotel.Location.Name,
                Catering = hotel.CateringType.Name,
                Category = hotel.Category.Name,
                DoubleRoomPrice = hotel.DoubleRoomPrice,
                StudioPrice = hotel.StudioRoomPrice,
                ApartmentPrice = hotel.ApartmentRoomPrice,
                Star = hotel.Star,
                Description = hotel.Description,
                LikeCount = hotel.WishLists.Count
            };

            viewModel.Images = images;
            viewModel.Posts = posts;

            return viewModel;
        }

        public async Task<IEnumerable<int>> AllStarsAsync()
        {
            IEnumerable<int> allStarCategory = new List<int>()
            {
                2, 3, 4, 5
            };

            return allStarCategory;
        }

        public async Task<bool> HotelExistByIdAsync(int hotelId)
        {
            bool result = await this.dbContext
                .Hotels
                .Where(h => h.IsActive)
                .AnyAsync(a => a.Id == hotelId);

            return result;
        }

        public async Task<HotelFormModel> GetHotelForEditByIdAsync(int id)
        {
            Hotel hotel = await this.dbContext
                .Hotels
                .Include(h => h.Category)
                .Include(h => h.Location)
                .Include(h => h.CateringType)
                .Include(h => h.Posts)
                .Include(h => h.Images)
                .FirstAsync(h => h.IsActive && h.Id == id);


            return new HotelFormModel
            {
                Title = hotel.Title,
                Location = hotel.Location.Name,
                Star = hotel.Star,
                CategoryId = hotel.CategoryId,
                CateringTypeId = hotel.CateringTypeId,
                Description = hotel.Description,
                Images = hotel.Images.Select(h => h.ImageUrl).ToList(),
                DoubleRoomPrice = hotel.DoubleRoomPrice,
                StudioPrice = hotel.StudioRoomPrice,
                ApartmentPrice = hotel.ApartmentRoomPrice,

            };
        }

        public async Task EditHotelByIdAndFormModelAsync(int hotelId, HotelFormModel model)
        {
            var hotel = await this.dbContext.Hotels
                .Include(h => h.Location)
                .Include(h => h.Images)
                .FirstOrDefaultAsync(h => h.Id == hotelId && h.IsActive);

            if (hotel != null)
            {
                hotel.Title = model.Title;
                hotel.Location.Name = model.Location;
                hotel.Star = model.Star;
                hotel.CategoryId = model.CategoryId;
                hotel.CateringTypeId = model.CateringTypeId;
                hotel.Description = model.Description;
                hotel.DoubleRoomPrice = model.DoubleRoomPrice;
                hotel.StudioRoomPrice = model.StudioPrice;
                hotel.ApartmentRoomPrice = model.ApartmentPrice;

                var imageUrls = model.Images;
                var oldImages = hotel.Images.ToList();

                foreach (var oldImage in oldImages)
                {
                    if (!imageUrls.Contains(oldImage.ImageUrl))
                    {
                        hotel.Images.Remove(oldImage);
                    }
                }

                List<Image> newImages = new List<Image>();

                newImages = imageUrls.Select(imageUrl => new Image
                {
                    ImageUrl = imageUrl,
                    IsMain = (hotel.Images.Count == 0),
                    HotelId = hotel.Id
                }).ToList();

                foreach (var newImage in newImages)
                {
                    if (oldImages.All(i => i.ImageUrl != newImage.ImageUrl))
                    {
                        hotel.Images.Add(newImage);
                    }
                }

                await this.dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Hotel not found or not active.");
            }
        }

        public async Task<HotelForDeleteViewModel> GetHotelForDeleteByIdAsync(int hotelId)
        {
            Hotel hotel = await this.dbContext
                .Hotels
                .Include(h => h.Location)
                .Include(h => h.Images)
                .FirstAsync(h => h.IsActive && h.Id == hotelId);


            return new HotelForDeleteViewModel
            {
                Title = hotel.Title,
                Location = hotel.Location.Name,
                Description = hotel.Description,
                ImageUrl = hotel.Images.First().ImageUrl,
                Price = hotel.DoubleRoomPrice,
            };

        }

        public async Task DeleteHotelByIdAsync(int hotelId)
        {
            Hotel hotel = await this.dbContext
                .Hotels
                .Where(h => h.IsActive)
                .FirstAsync(h => h.Id == hotelId);

            hotel.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<HotelForReservationViewModel> GetHotelForReservationByAdAsync(int hotelId)
        {
            Hotel hotel = await this.dbContext
                .Hotels
                .Include(h => h.Category)
                .Include(h => h.Location)
                .Include(h => h.CateringType)
                .Include(h => h.Images)
                .Include(h => h.RoomTypes)
                .FirstAsync(h => h.IsActive && h.Id == hotelId);


            HotelForReservationViewModel viewModel = new HotelForReservationViewModel
            {
                Id = hotel.Id,
                Title = hotel.Title,
                ImageUrl = hotel.Images.First(i => i.IsMain).ImageUrl,
                Location = hotel.Location.Name,
                Category = hotel.Category.Name,
                CateringType = hotel.CateringType.Name,
                Star = hotel.Star,
                AccommodationDate = DateTime.Today,
                DepartureDate = DateTime.Today,
                DoubleRoomPrice = hotel.DoubleRoomPrice,
                StudioPrice = hotel.StudioRoomPrice,
                ApartmentPrice = hotel.ApartmentRoomPrice,
                RoomTypes = hotel.RoomTypes.Select(i => i.Name).ToList(),
            };

            return viewModel;
        }

        
        public async Task AddReservation(int id, HotelForReservationViewModel viewModel, string userId)
        {
            // Изчисляваме броя нощувки
            TimeSpan timeSpan = viewModel.DepartureDate - viewModel.AccommodationDate;
            int days = (int)timeSpan.TotalDays;

            // Изчисляваме общата цена
            Decimal totalPrice = 0;
            if (viewModel.SelectedRoomType == "DoubleRoom")
            {
                totalPrice = viewModel.DoubleRoomPrice * days;
            }
            else if (viewModel.SelectedRoomType == "Studio")
            {
                totalPrice = viewModel.StudioPrice * days;
            }
            else if (viewModel.SelectedRoomType == "Apartment")
            {
                totalPrice = viewModel.ApartmentPrice * days;
            }

            Order order = new Order
            {
                UserId = Guid.Parse(userId),
                HotelId = id,
                RoomType = viewModel.SelectedRoomType,
                АccommodationDate = viewModel.AccommodationDate,
                DepartureDate = viewModel.DepartureDate,
                Days = days,
                Price = viewModel.SelectedRoomType == "Double" ? viewModel.DoubleRoomPrice :
                    viewModel.SelectedRoomType == "Studio" ? viewModel.StudioPrice :
                    viewModel.SelectedRoomType == "Apartment" ? viewModel.ApartmentPrice : 0,
                TotalPrice = totalPrice
            };

            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync();
        }




    }
}
