namespace TravelAgency.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using Web.ViewModels.Reservation;

    public class ReservationController : BaseAdminController
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }
        
        
        [Route("Reservation/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<ReservationViewModel> allReservation = await this.reservationService.AllAsync();
            
            
            return this.View(allReservation);
        }
    }
}
