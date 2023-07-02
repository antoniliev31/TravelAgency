namespace TravelAgency.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;

    using Interfaces;
    using Web.ViewModels.Home;

    public class HouseService : IHouseService
    {
        private readonly TravelAgencyDbContext dbContext;

        public HouseService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<IndexViewModel>> LastThreeHouseAsync()
        {
            IEnumerable<IndexViewModel> lastThreeHouse = await this.dbContext
                .Houses
                .OrderByDescending(h => h.CreatedOn)
                .Take(3)
                .Select(h => new IndexViewModel
                {
                    Id = h.Id.ToString(),
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .ToArrayAsync();

            return lastThreeHouse;
        }
    }
}
