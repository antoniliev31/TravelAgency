using Microsoft.AspNetCore.Authorization;

namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class HouseController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
