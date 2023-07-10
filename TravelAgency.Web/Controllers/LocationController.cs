namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TravelAgency.Services.Data.Interfaces;

    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            this._locationService = locationService;
        }


        
    }
}
