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


        public async Task<IEnumerable<HotelSelectCategoryFormModel>> AllCategoryesAsync()
        {
            IEnumerable<HotelSelectCategoryFormModel> allCategories = await this.dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new HotelSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCategories;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            bool result = await this.dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<IEnumerable<string>> AllCategoryNamesAsync()
        {
            IEnumerable<string> allNames = await this.dbContext
                .Categories
                .Select(c => c.Name)
                .ToArrayAsync();

            return allNames;
        }

    }
}
