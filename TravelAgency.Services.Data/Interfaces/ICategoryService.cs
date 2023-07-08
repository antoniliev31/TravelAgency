namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<HouseSelectCategoryFormModel>> AllCategoryesAsync();

        Task<bool> ExistByIdAsync(int id);
    }
}
