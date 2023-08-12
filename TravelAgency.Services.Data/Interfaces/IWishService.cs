namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.User;

    public interface IWishService
    {
        Task AddHotelToWishListAsync(int hotelId, string userId);

        Task RemoveHotelFromWishListAsync(int hotelId, string userId);

        Task<bool> IsHotelInWishListAsync(int hotelId, string userId);
       
    }
}
