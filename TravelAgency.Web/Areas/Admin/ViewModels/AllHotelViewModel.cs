namespace TravelAgency.Web.Areas.Admin.ViewModels
{
    using Web.ViewModels.Hotel;

    public class AllHotelViewModel
    {
        public IEnumerable<HotelAllViewModel> AllReservations { get; set; } = null!;
    }
}
