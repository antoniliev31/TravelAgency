namespace TravelAgency.Web.ViewModels.Hotel
{
    using System.ComponentModel.DataAnnotations;
    using Catering;
    using Room;
    using Category;
    using static Common.EntityValidationConstants.Hotel;
    using static Common.EntityValidationConstants.Category;

    public class HotelFormModel
    {
        public HotelFormModel()
        {
            this.Categories = new HashSet<HotelSelectCategoryFormModel>();
            this.Caterings = new HashSet<HotelSelectCateringFormModel>();
        }
        
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Име на хотела")]
        public string Title { get; set; } = null!;
        

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        [Display(Name = "Населено място")]
        public string Location { get; set; } = null!;
        
        [Range(StarMinValue, StarMaxValue)]
        [Display(Name = "Категория (Звезди)")]
        public int Star { get; set; }

        [Required]
        [Display(Name = "Тип на хотела")]
        public int CategoryId { get; set; }

        [Required]
        [Range(CateringTypeMinLength, CateringTypeMaxLength)]
        [Display(Name = "Изберете тип изхранването на гостите [B], [BB], [HB], [FB], [All]")]
        public int CateringTypeId { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;

        [Required]
        [Display(Name = "Добавете линк към снимките на хотела, като започнете с главната")]
        public List<string> Images { get; set; } = new List<string>();


        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Цена за двойна став")]
        public decimal DoubleRoomPrice { get; set; }

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Цена за студио")]
        public decimal StudioPrice { get; set; }

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Display(Name = "Цена за апартамент")]
        public decimal ApartmentPrice { get; set; }


        [Required]
        public bool IsActive { get; set; }


        public IEnumerable<HotelSelectCategoryFormModel> Categories { get; set; }

        public IEnumerable<HotelSelectCateringFormModel> Caterings { get; set; }

    }
}
