﻿namespace TravelAgency.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WishList
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(ApplicationUser))]
        public Guid UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; } = null!;


        [ForeignKey(nameof(Hotel))]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; } = null!;

    }
}
