namespace TravelAgency.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string? Text { get; set; }

    }
}
