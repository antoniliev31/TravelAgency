namespace TravelAgency.Services.Data
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Web.ViewModels.Category;
    using Web.ViewModels.Catering;

    public class CateringService : ICateringService
    {
        private readonly TravelAgencyDbContext dbContext;

        public CateringService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<IEnumerable<HotelSelectCateringFormModel>> AllCateringTypesAsync()
        {
            IEnumerable<HotelSelectCateringFormModel> allCateringTypes = await this.dbContext
                .CateringTypes
                .AsNoTracking()
                .Select(c => new HotelSelectCateringFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allCateringTypes;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            bool result = await this.dbContext
                .CateringTypes
                .AnyAsync(c => c.Id == id);

            return result;
        }
        
    }
}
