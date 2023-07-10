namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using static Common.EntityValidationConstants.City;
    
    public class Location
    {
        public Location()
        {
            this.HotelsInThisLocation = new HashSet<Hotel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CityMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Hotel> HotelsInThisLocation { get; set; }
    }
}
