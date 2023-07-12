namespace TravelAgency.Web.ViewModels.Hotel
{
    using Agent;
    using Post;

    public class HotelDetailsViewModel : HotelAllViewModel
    {
        public string Description { get; set; } = null!;


        public AgentInfoOnHotelViewModel Agent { get; set; } = null!;


        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
    }
}
