namespace TravelAgency.Data.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationConstants.Hotel;
    using Common;

    public class Hotel
    {
        public Hotel()
        {
            this.Id = Guid.NewGuid();
            this.Posts = new HashSet<Post>();
            this.WishLists = new HashSet<WishList>();
            this.OrderLists = new HashSet<OrderList>();
        }

        [Key]
        public Guid Id { get; set; }


        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;


        [MaxLength(SubTitleMaxLength)]
        public string? SubTitle { get; set; }


        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; } = null!;
        

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;


        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;


        [ForeignKey(nameof(CateringType))]
        public int CateringTypeId { get; set; }
        public virtual CateringType CateringType { get; set; } = null!;


        [Range(StarMinValue, StarMaxValue)]
        public int Star { get; set; }


        [Required]
        [MaxLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;


        public DateTime CreatedOn { get; set; }


        public decimal Price { get; set; }


        [Required]  
        public byte IsActive { get; set; } = 1;
        

        [ForeignKey(nameof(Agent))]
        public Guid AgentId { get; set; }
        public virtual Agent Agent { get; set; } = null!;


        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; } = null!;
        

        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public virtual ICollection<OrderList> OrderLists { get; set; }
    }
}
