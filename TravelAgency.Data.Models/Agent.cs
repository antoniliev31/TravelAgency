﻿namespace TravelAgency.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    
    using static Common.EntityValidationConstants.Agent;

    public class Agent
    {
        public Agent()
        {
            this.OwnedHouses = new HashSet<House>();
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public ICollection<House> OwnedHouses { get; set; }
    }
}
