namespace TravelAgency.Web.ViewModels.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using Image;
    using TravelAgency.Web.ViewModels.Category;
    using TravelAgency.Web.ViewModels.Catering;
    using TravelAgency.Web.ViewModels.Room;

    public class HotelForDeleteViewModel
    {
        
        [Display(Name = "Хотел")]
        public string Title { get; set; } = null!;

        [Display(Name = "Местоположение")]
        public string Location { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

    }
}
