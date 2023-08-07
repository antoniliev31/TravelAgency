namespace TravelAgency.Web.Controllers;

using Data.Models;
using Microsoft.AspNetCore.Mvc;

using TravelAgency.Services.Data.Interfaces;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ViewModels.User;

[Authorize]
public class UserController : Controller
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    //private readonly IUserStore<UserController> userStore;
    private readonly IUserService userService;

    public UserController(IUserService userService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        //this.userStore = userStore;
        this.userService = userService;
    }


    [AllowAnonymous]
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return this.View(model);
        }

        ApplicationUser user = new ApplicationUser()
        {
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        await this.userManager.SetEmailAsync(user, model.Email);
        await this.userManager.SetUserNameAsync(user, model.Email);
        IdentityResult result =
            await this.userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        await this.signInManager.SignInAsync(user, false);
        return this.RedirectToAction("Index", "Home");
    }



    [HttpGet]
    public async Task<IActionResult> Order()
    {
        List<UserAllReservationViewModel> myOredr = new List<UserAllReservationViewModel>();

        string userId = this.User.GetId()!;


        myOredr.AddRange(await this.userService.AllUserReservationAsync(userId!));


        return this.View(myOredr);
    }
}