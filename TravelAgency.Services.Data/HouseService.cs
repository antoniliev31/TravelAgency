using TravelAgency.Data.Models;

namespace TravelAgency.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;

    using Interfaces;
    using Web.ViewModels.Home;
    using System;

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

        
    }
}
