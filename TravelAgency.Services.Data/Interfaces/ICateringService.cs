namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.Catering;

    public interface ICateringService
    {
        Task<IEnumerable<HotelSelectCateringFormModel>> AllCateringTypesAsync();

        Task<bool> ExistByIdAsync(int id);
        
    }
}
