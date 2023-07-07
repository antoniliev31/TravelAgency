namespace TravelAgency.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string? Text { get; set; }

        public List<PostViewModel>? PostsList{ get; set; }
    }
}
