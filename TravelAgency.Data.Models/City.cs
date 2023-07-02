namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using static Common.EntityValidationConstants.City;
    
    public class City
    {
        public City()
        {
            this.HosesInCity = new HashSet<House>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<House> HosesInCity { get; set; }
    }
}
