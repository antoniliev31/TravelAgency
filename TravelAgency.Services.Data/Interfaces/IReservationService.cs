namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.Reservation;

    public interface IReservationService
    {
        Task<IEnumerable<ReservationViewModel>> AllAsync();
    }
}
