namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.CateringType;

    public class CateringType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CateringNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
