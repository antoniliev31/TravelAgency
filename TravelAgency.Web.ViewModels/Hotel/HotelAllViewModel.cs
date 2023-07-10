namespace TravelAgency.Web.ViewModels.House
{
    using System.ComponentModel.DataAnnotations;

    public class HotelAllViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string? SubTitle { get; set; }

        public string Location { get; set; } = null!;

        public string Catering { get; set; } = null!;

        public int Category { get; set; }

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int Star { get; set; }
        public string RoomType { get; set; } = null!;
    }
}
