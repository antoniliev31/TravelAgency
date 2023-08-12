namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.Reservation;

    public interface IReservationService
    {
        Task<IEnumerable<ReservationViewModel>> AllAsync();

        Task CancelReservationAsync(int reservationId);

        Task<bool> ReservationExistById(int id);

    }
}
