namespace TravelAgency.Web.ViewModels.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        
        public string UserName { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
