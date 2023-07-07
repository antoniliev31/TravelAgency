namespace TravelAgency.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using TravelAgency.Services.Data.Interfaces;
    using ViewModels.Home;
    

    public class HomeController : Controller
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService houseService)
        {
            this.houseService = houseService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = await this.houseService.LastThreeHouseAsync();

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ViewModels.Home.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}