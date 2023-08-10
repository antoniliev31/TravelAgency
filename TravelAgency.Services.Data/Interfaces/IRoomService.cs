namespace TravelAgency.Services.Data.Interfaces
{
    using TravelAgency.Web.ViewModels.Category;
    using Web.ViewModels.Room;

    public interface IRoomService
    {
        Task<IEnumerable<HotelSelectRoomFormModel>> AllRoomTypeAsync();

        Task<bool> ExistByIdAsync(int id);
        
    }
}
