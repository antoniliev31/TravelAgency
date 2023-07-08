namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TravelAgency.Services.Data.Interfaces;

    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }


        
    }
}
