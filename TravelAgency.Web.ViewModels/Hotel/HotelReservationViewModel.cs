namespace TravelAgency.Web.ViewModels.Hotel
{
    public class HotelReservationViewModel
    {
        public HotelReservationViewModel()
        {
            this.RoomTypesPrice = new Dictionary<string, decimal>();
        }
        
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Locatioin { get; set; } = null!;

        public int Star { get; set; }

        public DateTime АccommodationDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public decimal DoubleRoomPrice { get; set; }

        public decimal StudioPrice { get; set; }

        public decimal ApartmentPrice { get; set; }

        public Dictionary<string, decimal> RoomTypesPrice { get; set; }

    }
}
