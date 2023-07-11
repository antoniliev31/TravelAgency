namespace TravelAgency.Web.ViewModels.House
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
            this.Hotels = new HashSet<HotelAllViewModel>();
            this.Locations = new HashSet<string>();
        }
        
        [Display(Name = "Търси по категория")]
        public string? Category { get; set; }

        [Display(Name = "Търси по населено място")]
        public string? Location { get; set; }

        [Display(Name = "Търси по име")]
        public string? SearchString { get; set; }

        [Display(Name = "Подреди по")]
        public HotelSorting HotelSorting { get; set; }

        [Display(Name = "Настояща страница")]
        public int CurrentPage { get; set; }
        
        [Display(Name = "Брой страници")]
        public int HotelsPerPage { get; set; }

        [Display(Name = "Общо хотели")]
        public int TotalHotels { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Locations { get; set; }

        public IEnumerable<HotelAllViewModel> Hotels { get; set; }


    }
}
