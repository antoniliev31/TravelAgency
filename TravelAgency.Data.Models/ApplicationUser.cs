namespace TravelAgency.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.RentedHouses = new HashSet<House>();
            this.MyPosts = new HashSet<Post>();
        }

        public virtual ICollection<House> RentedHouses { get; set; }

        public virtual ICollection<Post> MyPosts { get; set; }
    }
}
