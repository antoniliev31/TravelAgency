namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using TravelAgency.Services.Data.Interfaces;
    using ViewModels.Home;

    using static Common.GeneralApplicationConstants;
    

    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;

        public HomeController(IHotelService hotelService)
        {
            this._hotelService = hotelService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(AdminRoleName))
            {
                return this.RedirectToAction("Index", "Home", new {Area = AdminAreaName});
            }


            IEnumerable<IndexViewModel> viewModel = await this._hotelService.LastThreeAddedHotelAsync();

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404 || statusCode == 400)
            {
                return this.View("Error404");
            }

            if (statusCode == 401)
            {
                return this.View("Error401");
            }

            return this.View();
        }
    }
}