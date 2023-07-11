using TravelAgency.Data.Models;
using TravelAgency.Web.ViewModels.House;

namespace TravelAgency.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;

    using Interfaces;
    using Web.ViewModels.Home;
    using System;
    using Models.House;
    using Web.ViewModels.Hotel;
    using Web.ViewModels.House.Enums;

    public class HotelService : IHotelService
    {
        private readonly TravelAgencyDbContext dbContext;

        public HotelService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeHouseAsync()
        {
            var lastThreeHouse = await this.dbContext
                .Hotels
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(h => new IndexViewModel
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
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
            Hotel newHotel = new Hotel
            {
                Title = formModel.Title,
                SubTitle = formModel.SubTitle,
                LocationId = locationId,
                Description = formModel.Description,
                CategoryId = formModel.CategoryId,
                CateringTypeId = formModel.CateringTypeId,
                Star = formModel.Star,
                ImageUrl = formModel.ImageUrl,
                Price = formModel.Price,
                AgentId = Guid.Parse(agentId),
                RoomTypeId = formModel.RoomTypeId,
                IsActive = true
            };

            await this.dbContext.Hotels.AddAsync(newHotel);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AllHotelsFilteredAndPagesServiceModel> AllAsync(AllHotelQueryModel queryModel)
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
                    SubTitle = h.SubTitle,
                    Location = h.Location.Name,
                    Star = h.Star,
                    RoomType = h.RoomType.Name,
                    Catering = h.CateringType.Name,
                    ImageUrl = h.ImageUrl,
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
    }
}
