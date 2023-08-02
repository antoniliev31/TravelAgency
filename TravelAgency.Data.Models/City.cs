namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using static Common.EntityValidationConstants.City;
    
    public class City
    {
        public City()
        {
            this.HotelInCity = new HashSet<Hotel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CityMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Hotel> HotelInCity { get; set; }
    }
}
