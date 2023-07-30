namespace TravelAgency.Web.ViewModels.Hotel
{
    using Interfaces;

    public class HotelAllViewModel : IHotelModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Catering { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal DoubleRoomPrice { get; set; }

        public decimal StudioPrice { get; set; }

        public decimal ApartmentPrice { get; set; }

        public int Star { get; set; }

        public string RoomType { get; set; } = null!;

    }
}
