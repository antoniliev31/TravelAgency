namespace TravelAgency.Web.ViewModels.House
{
    using System.ComponentModel.DataAnnotations;

    using Category;

    using static Common.EntityValidationConstants.House;

    public class HouseFormModel
    {
        public HouseFormModel()
        {
            this.Categories = new HashSet<HouseSelectCategoryFormModel>();
        }
        
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<HouseSelectCategoryFormModel> Categories { get; set; }
    }
}
