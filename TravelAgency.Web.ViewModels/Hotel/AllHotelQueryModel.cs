namespace TravelAgency.Web.ViewModels.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using static Common.GeneralApplicationConstants;

    public class AllHotelQueryModel
    {
        public AllHotelQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.HotelsPerPage = EntitiesPerPage;
            this.Categories = new HashSet<string>();
            this.Stars = new HashSet<int>();
            this.Hotels = new HashSet<HotelAllViewModel>();
            this.Locations = new HashSet<string>();
        }
        
        [Display(Name = "Тип на хотела")]
        public string? Category { get; set; }

        [Display(Name = "Категория(звезди)")]
        public int Star { get; set; }

        [Display(Name = "Местоположение")]
        public string? Location { get; set; }

        [Display(Name = "Търси по име")]
        public string? SearchString { get; set; }

        [Display(Name = "Подреди по")]
        public HotelSorting HotelSorting { get; set; }

        [Display(Name = "Настояща страница")]
        public int CurrentPage { get; set; }
        
        [Display(Name = "Покажи на страница по:")]
        public int HotelsPerPage { get; set; }

        [Display(Name = "Общо хотели")]
        public int TotalHotels { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Locations { get; set; }

        public IEnumerable<int> Stars { get; set; }

        public IEnumerable<HotelAllViewModel> Hotels { get; set; }

    }
}
