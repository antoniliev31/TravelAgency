namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;
    
    using static Common.EntityValidationConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.MyWishLists = new HashSet<WishList>();
            this.MyOrders = new HashSet<Order>();
            this.MyPosts = new HashSet<Post>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;


        public virtual ICollection<WishList> MyWishLists { get; set; }

        public virtual ICollection<Order> MyOrders { get; set; }

        public virtual ICollection<Post> MyPosts { get; set; }
    }
}
