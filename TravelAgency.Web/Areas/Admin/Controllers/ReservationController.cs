namespace TravelAgency.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Services.Data.Interfaces;
    using Web.ViewModels.Reservation;

    using static Common.GeneralApplicationConstants;

    public class ReservationController : BaseAdminController
    {
        private readonly IReservationService reservationService;
        private readonly IMemoryCache memoryCache;

        public ReservationController(IReservationService reservationService, IMemoryCache memoryCache)
        {
            this.reservationService = reservationService;
            this.memoryCache = memoryCache;
        }
        
        
        [Route("Reservation/All")]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Client, NoStore = false)]
        public async Task<IActionResult> All()
        {
            var allReservation = await this.reservationService.AllAsync();

            //IEnumerable<ReservationViewModel> allReservation =
            //    this.memoryCache.Get<IEnumerable<ReservationViewModel>>(ReservationsCacheKey);
            //if (allReservation == null)
            //{
            //    allReservation = await this.reservationService.AllAsync();

            //    MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
            //        .SetAbsoluteExpiration(TimeSpan.FromMinutes(ReservationCacheDurationMinutes));

            //    this.memoryCache.Set(UserCacheKey, allReservation, cacheOptions);
            //}
            
            return this.View(allReservation);
        }
    }
}
