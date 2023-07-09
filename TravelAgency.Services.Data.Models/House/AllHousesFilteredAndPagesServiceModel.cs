namespace TravelAgency.Services.Data.Models.House
{
    using Web.ViewModels.House;

    public class AllHousesFilteredAndPagesServiceModel
    {
        public AllHousesFilteredAndPagesServiceModel()
        {
            this.Houses = new HashSet<HouseAllViewModel>();
        }
        
        public int TotalHousesCount { get; set; }

        public IEnumerable<HouseAllViewModel> Houses { get; set; }
    }
}