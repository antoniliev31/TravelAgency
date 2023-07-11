namespace TravelAgency.Services.Data.Models.House
{
    using Web.ViewModels.House;

    public class AllHotelsFilteredAndPagesServiceModel
    {
        public AllHotelsFilteredAndPagesServiceModel()
        {
            this.Hotels = new HashSet<HotelAllViewModel>();
        }
        
        public int TotalHotelsCount { get; set; }

        public IEnumerable<HotelAllViewModel> Hotels { get; set; }
    }
}