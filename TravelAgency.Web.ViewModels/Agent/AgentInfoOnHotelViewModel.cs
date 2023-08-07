namespace TravelAgency.Web.ViewModels.Agent
{
    using System.ComponentModel.DataAnnotations;
    

    public class AgentInfoOnHotelViewModel
    {
        public string FullName { get; set; } = null!;
        
        [Display(Name = "e-mail:")]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; } = null!;

    }
}
