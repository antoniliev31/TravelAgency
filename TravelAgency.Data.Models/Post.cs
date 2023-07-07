using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Post;

    public class Post
    {
        public Post()
        {
            
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(PostMaxLength)]
        public string Content { get; set; } = null!;


        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [ForeignKey(nameof(House))]
        public Guid HouseId { get; set; }
        public virtual House House { get; set; } = null!;


        




    }
}
