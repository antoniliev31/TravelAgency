namespace TravelAgency.Web.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string UserFullName { get; set; } = null!;

        public string UserEmail { get; set; } = null!;

        public string? UserPhoneNumber { get; set; }

        public DateTime AccommodationDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int Days { get; set; }

        public Decimal Price { get; set; }

        public Decimal TotalPrice { get; set; }


    }
}
