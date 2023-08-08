namespace TravelAgency.Web.ViewModels.Hotel
{
    using Image;
    using Post;

    public class HotelDetailsViewModel : HotelAllViewModel
    {
        public string Description { get; set; } = null!;

        public int LikeCount { get; set; }

        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();

        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();


    }
}
