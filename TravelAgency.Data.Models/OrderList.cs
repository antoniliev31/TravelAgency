namespace TravelAgency.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderList
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;


        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; } = null!;


        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; } = null!;

        public DateTime АccommodationDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int Days { get; set; }

        public Decimal Price { get; set; }

        public Decimal TotalPrice { get; set; }
    }
}
