namespace TravelAgency.Services.Data
{
    using Microsoft.EntityFrameworkCore;

    using Interfaces;
    using Web.ViewModels.Category;
    using TravelAgency.Data;

    public class CategoryService : ICategoryService
    {
        private readonly TravelAgencyDbContext dbContext;

        public CategoryService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoryesAsync()
        {
            IEnumerable<HouseSelectCategoryFormModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new HouseSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}
