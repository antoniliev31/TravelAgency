namespace TravelAgency.Web.Controllers;

using Microsoft.AspNetCore.Mvc;

using TravelAgency.Services.Data.Interfaces;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using ViewModels.User;

[Authorize]
public class UserController : Controller
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
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