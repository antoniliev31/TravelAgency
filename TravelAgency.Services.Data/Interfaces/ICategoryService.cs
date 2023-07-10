namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.Category;

    public interface ICategoryService
    {
        Task<IEnumerable<HotelSelectCategoryFormModel>> AllCategoryesAsync();

        Task<bool> ExistByIdAsync(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();
    }
}
