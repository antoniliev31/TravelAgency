namespace TravelAgency.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    

    public class HomeController : BaseAdminController
    {
        
        
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
