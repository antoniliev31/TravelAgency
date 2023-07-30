namespace TravelAgency.Web.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Linq;

    public class UserAllReservationViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; } = null!;

        public int HotelId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Location { get; set; } = null!;

        public int Star { get; set; }

        public string Category { get; set; } = null!;

        public string CateringType { get; set; } = null!;

        public string RoomType { get; set; } = null!;

        [Display(Name = "Дата на настаняване")]
        [DataType(DataType.Date)]
        public DateTime AccommodationDate { get; set; }

        [Display(Name = "Дата на напускане")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        public string SelectedRoomType { get; set; } = null!;

        public int NightsCount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
