﻿namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Interfaces;
    using static Common.EntityValidationConstants.Hotel;
    

    public class Hotel
    {
        public Hotel()
        {
            this.Posts = new HashSet<Post>();
            this.WishLists = new HashSet<WishList>();
            this.OrderLists = new HashSet<Order>();
            this.Images = new HashSet<Image>();
            this.RoomTypes = new HashSet<RoomType>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Range(StarMinValue, StarMaxValue)]
        public int Star { get; set; }
        
        public DateTime CreatedOn { get; set; }

        public decimal DoubleRoomPrice { get; set; }

        public decimal StudioRoomPrice { get; set; }

        public decimal ApartmentRoomPrice { get; set; }
        
        [Required]  
        public bool IsActive { get; set; }


        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; } = null!;
        
        
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;


        [ForeignKey(nameof(CateringType))]
        public int CateringTypeId { get; set; }
        public virtual CateringType CateringType { get; set; } = null!;



        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<WishList> WishLists { get; set; }

        public virtual ICollection<Order> OrderLists { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<RoomType> RoomTypes { get; set; }
    }
}
