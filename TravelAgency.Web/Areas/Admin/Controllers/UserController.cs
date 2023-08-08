namespace TravelAgency.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Data.Interfaces;
    using Web.ViewModels.User;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> AllUsers()
        {
            IEnumerable<UserViewModel> viewModel = await this.userService.AllUserAsync();

            return View(viewModel);
        }
    }
}
