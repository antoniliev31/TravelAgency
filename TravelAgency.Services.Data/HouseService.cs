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
    using Web.ViewModels.House.Enums;

    public class HouseService : IHouseService
    {
        private readonly TravelAgencyDbContext dbContext;

        public HouseService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeHouseAsync()
        {
            var lastThreeHouse = await this.dbContext
                .Houses
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
                    .Where(p => p.HouseId == Guid.Parse(house.Id))
                    .ToListAsync();

                if (posts.Count > 0)
                {
                    int randomIndex = random.Next(0, posts.Count);
                    house.Text = posts[randomIndex].Content;
                }
            }

            return lastThreeHouse;
        }

        public async Task CreateHouseAsync(HouseFormModel formModel, string agentId, int cityId)
        {
            House newHouse = new House
            {
                Title = formModel.Title,
                CategoryId = formModel.CategoryId,
                CityId = cityId,
                Address = formModel.Address,
                Description = formModel.Description,
                ImageUrl = formModel.ImageUrl,
                Price = 0,
                AgentId = Guid.Parse(agentId)

            };

            await this.dbContext.Houses.AddAsync(newHouse);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AllHousesFilteredAndPagesServiceModel> AllAsync(AllHousesQueryModel queryModel)
        {
            IQueryable<House> housesQuery = this.dbContext
                .Houses
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                housesQuery = housesQuery
                    .Where(h => h.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                housesQuery = housesQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                                EF.Functions.Like(h.Address, wildCard) ||
                                EF.Functions.Like(h.Description, wildCard));
            }

            if (!string.IsNullOrWhiteSpace(queryModel.City))
            {
                housesQuery = housesQuery
                    .Where(h => h.City.Name == queryModel.City);
            }

            housesQuery = queryModel.HouseSorting switch
            {
                HouseSorting.Newest => housesQuery
                    .OrderBy(h => h.CreatedOn),
                HouseSorting.Oldest => housesQuery
                    .OrderByDescending(h => h.CreatedOn),
                HouseSorting.CityAscending => housesQuery
                    .OrderBy(h => h.City),
                HouseSorting.CityDescending => housesQuery
                    .OrderByDescending(h => h.City),
                HouseSorting.PriceAscending => housesQuery
                    .OrderBy(h => h.Price),
                HouseSorting.PriceDescending => housesQuery
                    .OrderByDescending(h => h.Price),
                _ => housesQuery
                    .OrderByDescending(h => h.Price)
            };

            IEnumerable<HouseAllViewModel> allHouses = await housesQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.HousesPerPage)
                .Take(queryModel.HousesPerPage)
                .Select(h => new HouseAllViewModel
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    City = h.City.Name,
                    Address = h.Address,
                    ImageUrl = h.ImageUrl,
                    Price = h.Price
                })
                .ToArrayAsync();

            int totalHouses = housesQuery.Count();

            return new AllHousesFilteredAndPagesServiceModel
            {
                TotalHousesCount = totalHouses,
                Houses = allHouses
            };
        }
    }
}
