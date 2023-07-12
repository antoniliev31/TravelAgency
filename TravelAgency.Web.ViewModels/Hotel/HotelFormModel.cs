namespace TravelAgency.Web.ViewModels.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using Catering;
    using Room;
    using TravelAgency.Web.ViewModels.Category;
    using static Common.EntityValidationConstants.Hotel;
    using static Common.EntityValidationConstants.Category;

    public class HotelFormModel
    {
        public HotelFormModel()
        {
            this.Categories = new HashSet<HotelSelectCategoryFormModel>();
            this.Caterings = new HashSet<HotelSelectCateringFormModel>();
            this.Rooms = new HashSet<HotelSelectRoomFormModel>();
        }
        
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Hotel name")]
        public string Title { get; set; } = null!;

        
        [StringLength(SubTitleMaxLength, MinimumLength = SubTitleMinLength)]
        [Display(Name = "Subtitle")]
        public string? SubTitle { get; set; }

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        [Display(Name = "Location")]
        public string Location { get; set; } = null!;
        
        [Range(StarMinValue, StarMaxValue)]
        [Display(Name = "Category")]
        public int Star { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        [Required]
        [Range(CateringTypeMinLength, CateringTypeMaxLength)]
        [Display(Name = "Catering Type")]
        public int CateringTypeId { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        [Range(typeof(decimal), PricePerMonthMinValue, PricePerMonthMaxValue)]
        [Display(Name = "Total Price")]
        public decimal Price { get; set; }

        [Required]
        public bool IsActive { get; set; }


        public IEnumerable<HotelSelectCategoryFormModel> Categories { get; set; }

        public IEnumerable<HotelSelectCateringFormModel> Caterings { get; set; }

        public IEnumerable<HotelSelectRoomFormModel> Rooms { get; set; }
    }
}
