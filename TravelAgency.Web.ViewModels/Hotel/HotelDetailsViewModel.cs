namespace TravelAgency.Web.ViewModels.Hotel
{
    using Agent;
    using Image;
    using Post;
    using WishList;

    public class HotelDetailsViewModel : HotelAllViewModel
    {
        public string Description { get; set; } = null!;

        public int LikeCount { get; set; }

        public AgentInfoOnHotelViewModel Agent { get; set; } = null!;

        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();

        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();


    }
}
