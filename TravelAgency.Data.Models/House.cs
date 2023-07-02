namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using static Common.EntityValidationConstants.House;

    public class House
    {
        public House()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;
        

        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public virtual City City { get; set; } = null!;


        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;


        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;


        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;


        public DateTime CreatedOn { get; set; }

        public decimal Price { get; set; }


        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;


        [ForeignKey(nameof(Agent))]
        public Guid AgentId { get; set; }
        public virtual Agent Agent { get; set; } = null!;


        public Guid? RenterId { get; set; }

        public virtual ApplicationUser? Renter { get; set; }
    }
}
