namespace TravelAgency.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using TravelAgency.Services.Data.Interfaces;
    using ViewModels.Home;
    

    public class HomeController : Controller
    {
        private readonly IHotelService _hotelService;

        public HomeController(IHotelService hotelService)
        {
            this._hotelService = hotelService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = await this._hotelService.LastThreeAddedHotelAsync();

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ViewModels.Home.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}