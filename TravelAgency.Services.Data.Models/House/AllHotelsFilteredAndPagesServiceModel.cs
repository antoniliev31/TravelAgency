namespace TravelAgency.Services.Data.Models.House
{
    using Web.ViewModels.House;

    public class AllHotelsFilteredAndPagesServiceModel
    {
        public AllHotelsFilteredAndPagesServiceModel()
        {
            this.Houses = new HashSet<HotelAllViewModel>();
        }
        
        public int TotalHotelsCount { get; set; }

        public IEnumerable<HotelAllViewModel> Houses { get; set; }
    }
}