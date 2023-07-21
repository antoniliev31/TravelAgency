namespace TravelAgency.Web.ViewModels.Post
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Post;
    
    public class PostFormModel
    {
        
        [Required]
        [MaxLength(PostMaxLength)]
        public string Content { get; set; } = null!;
        
        
        public Guid UserId { get; set; }


        public int HotelId { get; set; }

    }
}
