﻿namespace TravelAgency.Web.ViewModels.Agent
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AgentInfoOnHotelViewModel
    {
        [Display(Name = "e-mail:")]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;

        

    }
}
