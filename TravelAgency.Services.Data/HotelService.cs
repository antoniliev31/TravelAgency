namespace TravelAgency.Services.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    
    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using Web.ViewModels.Hotel;
    using Interfaces;
    using Web.ViewModels.Home;
    using Models.House;
    using Web.ViewModels.Agent;
    using Web.ViewModels.Hotel.Enums;
    using Web.ViewModels.Image;
    using Web.ViewModels.Post;

    using static Common.EntityValidationConstants;
    using Hotel = TravelAgency.Data.Models.Hotel;

    public class HotelService : IHotelService
    {
        private readonly TravelAgencyDbContext dbContext;

        public HotelService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeAddedHotelAsync()
        {
            var lastThreeHouse = await this.dbContext
                .Hotels
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(h => new IndexViewModel
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    ImageUrl = h.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? h.Images.FirstOrDefault()!.ImageUrl
                })
                .ToListAsync();
            

            Random random = new Random();
            foreach (var house in lastThreeHouse)
            {
                var posts = await this.dbContext.Posts
                    .Where(p => p.HotelId == Guid.Parse(house.Id))
                    .ToListAsync();

                if (posts.Count > 0)
                {
                    int randomIndex = random.Next(0, posts.Count);
                    house.Text = posts[randomIndex].Content;
                }
            }

            return lastThreeHouse;
        }

        public async Task CreateHotelAsync(HotelFormModel formModel, string agentId, int locationId)
        {
            Hotel newhotel = new Hotel
            {
                Title = formModel.Title,
                LocationId = locationId,
                Description = formModel.Description,
                CategoryId = formModel.CategoryId,
                CateringTypeId = formModel.CateringTypeId,
                Star = formModel.Star,
                //Image = formModel.ImageUrl,
                Price = formModel.Price,
                AgentId = Guid.Parse(agentId),
                RoomTypeId = formModel.RoomTypeId,
                IsActive = true
            };
            Hotel newHotel = new Hotel
            {

                
            };



            await this.dbContext.Hotels.AddAsync(newHotel);
            await this.dbContext.SaveChangesAsync();
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

            hotelsQuery = queryModel.HotelSorting switch
            {
                HotelSorting.Newest => hotelsQuery
                    .OrderBy(h => h.CreatedOn),
                HotelSorting.Oldest => hotelsQuery
                    .OrderByDescending(h => h.CreatedOn),
                HotelSorting.CityAscending => hotelsQuery
                    .OrderBy(h => h.Location),
                HotelSorting.CityDescending => hotelsQuery
                    .OrderByDescending(h => h.Location),
                HotelSorting.PriceAscending => hotelsQuery
                    .OrderBy(h => h.Price),
                HotelSorting.PriceDescending => hotelsQuery
                    .OrderByDescending(h => h.Price),
                _ => hotelsQuery
                    .OrderByDescending(h => h.Price)
            };

            IEnumerable<HotelAllViewModel> allHotels = await hotelsQuery
                .Where(h => h.IsActive)
                .Skip((queryModel.CurrentPage - 1) * queryModel.HotelsPerPage)
                .Take(queryModel.HotelsPerPage)
                .Select(h => new HotelAllViewModel
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    Location = h.Location.Name,
                    Star = h.Star,
                    RoomType = h.RoomType.Name,
                    Catering = h.CateringType.Name,
                    ImageUrl = h.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                    Price = h.Price
                })
                .ToArrayAsync();

            int totalHouses = hotelsQuery.Count();

            return new AllHotelsFilteredAndPagesServiceModel
            {
                TotalHotelsCount = totalHouses,
                Hotels = allHotels
            };
        }

        public async Task<IEnumerable<HotelAllViewModel>> AllHotelByAgentIdAsync(string agentId)
        {
            IEnumerable<HotelAllViewModel> allAgentHotel = await this.dbContext
                .Hotels
                .Where(h => h.IsActive)
                .Where(h => h.AgentId == Guid.Parse(agentId))
                .Select(h => new HotelAllViewModel
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    Location = h.Location.Name,
                    Catering = h.CateringType.Name,
                    Category = h.Category.Name,
                    ImageUrl = h.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                    Price = h.Price,
                    Star = h.Star,
                    RoomType = h.RoomType.Name,
                })
                .ToArrayAsync();

            return allAgentHotel;
        }

        public async Task<IEnumerable<HotelAllViewModel>> AllWishHotelByUserAsync(string userId)
        {
            IEnumerable<HotelAllViewModel> allWishHotelByAgent = await this.dbContext
                .WishLists
                .Where(h => h.Hotel.IsActive)
                .Where(h => h.UserId == Guid.Parse(userId))
                .Select(h => new HotelAllViewModel
                {
                    Id = h.Hotel.Id.ToString(),
                    Title = h.Hotel.Title,
                    Location = h.Hotel.Location.Name,
                    Catering = h.Hotel.CateringType.Name,
                    Category = h.Hotel.Category.Name,
                    ImageUrl = h.Hotel.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                    Price = h.Hotel.Price,
                    Star = h.Hotel.Star,
                    RoomType = h.Hotel.RoomType.Name
                })
                .ToArrayAsync();

            return allWishHotelByAgent;
        }

        public async Task<IEnumerable<HotelAllViewModel>> AllOrderHotelByUserAsync(string userId)
        {
            IEnumerable<HotelAllViewModel> allOrderByUser = await this.dbContext
                .OrderLists
                .Where(h => h.Hotel.IsActive)
                .Where(h => h.UserId == Guid.Parse(userId))
                .Select(h => new HotelAllViewModel
                {
                    Id = h.Hotel.Id.ToString(),
                    Title = h.Hotel.Title,
                    Location = h.Hotel.Location.Name,
                    Catering = h.Hotel.CateringType.Name,
                    Category = h.Hotel.Category.Name,
                    ImageUrl = h.Hotel.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                    Price = h.Hotel.Price,
                    Star = h.Hotel.Star,
                    RoomType = h.Hotel.RoomType.Name
                })
                .ToArrayAsync();

            return allOrderByUser;
        }

        public async Task<HotelDetailsViewModel?> GetHotelDetailsByAdAsync(string hotelId)
        {
            var hotel = await this.dbContext
                .Hotels
                .Include(h => h.Category)
                .Include(h => h.Location)
                .Include(h => h.CateringType)
                .Include(h => h.RoomType)
                .Include(h => h.Agent)
                .ThenInclude(a => a.User)
                .Include(h => h.Posts)
                .Include(h => h.Images)
                .FirstOrDefaultAsync(h => h.IsActive && h.Id.ToString() == hotelId);

            if (hotel == null)
            {
                return null;
            }

            List<PostViewModel> posts = new List<PostViewModel>();

            foreach (var post in hotel.Posts)
            {
                var user = await this.dbContext.Users.FindAsync(post.UserId);
                var userName = user?.UserName ?? string.Empty;

                PostViewModel p = new PostViewModel
                {
                    Id = post.Id,
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
                Id = hotel.Id.ToString(),
                Title = hotel.Title,
                Location = hotel.Location.Name,
                Catering = hotel.CateringType.Name,
                Category = hotel.Category.Name,
                //ImageUrl = hotel.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? "",
                Price = hotel.Price,
                Star = hotel.Star,
                RoomType = hotel.RoomType.Name,
                Description = hotel.Description,
                Agent = new AgentInfoOnHotelViewModel
                {
                    Email = hotel.Agent.User.Email,
                    PhoneNumber = hotel.Agent.PhoneNumber
                }
            };

            viewModel.Images = images;
            viewModel.Posts = posts;

            return viewModel;
        }
    }
}
