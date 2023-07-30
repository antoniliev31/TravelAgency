namespace TravelAgency.Services.Data.Interfaces
{
    using TravelAgency.Services.Data.Models.House;
    using TravelAgency.Web.ViewModels.Hotel;
    using Web.ViewModels.User;

    public interface IUserService
    {
        Task<List<UserAllReservationViewModel>> AllUserReservationAsync(string id);
    }
}
