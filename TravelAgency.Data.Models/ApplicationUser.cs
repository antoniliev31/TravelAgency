namespace TravelAgency.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.MyWishLists = new HashSet<WishList>();
            this.MyOrders = new HashSet<Order>();
            this.MyPosts = new HashSet<Post>();
        }

        public virtual ICollection<WishList> MyWishLists { get; set; }

        public virtual ICollection<Order> MyOrders { get; set; }

        public virtual ICollection<Post> MyPosts { get; set; }
    }
}
