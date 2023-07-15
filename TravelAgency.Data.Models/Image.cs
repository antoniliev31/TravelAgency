namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.Image;

    public class Image
    {
        [Key]
        public int Id { get; set; }
        

        [Required]
        [MaxLength(ImageMaxLength)]
        public string ImageUrl { get; set; } = null!;


        [Required]
        public bool IsMain { get; set; }


        [ForeignKey(nameof(Hotel))]
        public Guid HotelId { get; set; }
        public virtual Hotel Hotel { get; set; } = null!;
    }
}
