namespace TravelAgency.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.LikedHotels = new HashSet<Hotel>();
            this.BookedHotels = new HashSet<Hotel>();
            this.MyPosts = new HashSet<Post>();
        }

        public virtual ICollection<Hotel> LikedHotels { get; set; }

        public virtual ICollection<Hotel> BookedHotels { get; set; }

        public virtual ICollection<Post> MyPosts { get; set; }
    }
}
