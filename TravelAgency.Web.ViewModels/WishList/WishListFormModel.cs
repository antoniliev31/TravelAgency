namespace TravelAgency.Web.ViewModels.WishList
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WishListFormModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int HotelId { get; set; }
        
    }
}
