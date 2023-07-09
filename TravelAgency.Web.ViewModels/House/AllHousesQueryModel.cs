namespace TravelAgency.Web.ViewModels.House
{
    using System.ComponentModel.DataAnnotations;
    using Enums;
    using static Common.GeneralApplicationConstants;

    public class AllHousesQueryModel
    {
        public AllHousesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.HousesPerPage = EntitiesPerPage;
            this.Categories = new HashSet<string>();
            this.Houses = new HashSet<HouseAllViewModel>();
            this.Cities = new HashSet<string>();
        }
        
        [Display(Name = "Търси по категория")]
        public string? Category { get; set; }

        [Display(Name = "Търси по населено място")]
        public string? City { get; set; }

        [Display(Name = "Търси по име")]
        public string? SearchString { get; set; }

        [Display(Name = "Подреди по")]
        public HouseSorting HouseSorting { get; set; }

        public int CurrentPage { get; set; }

        public int HousesPerPage { get; set; }

        public int TotalHouses { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public IEnumerable<HouseAllViewModel> Houses { get; set; }


    }
}
