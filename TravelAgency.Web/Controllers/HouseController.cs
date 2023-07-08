namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Infrastructure.Extensions;
    using TravelAgency.Services.Data.Interfaces;
    using ViewModels.House;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class HouseController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;
        private readonly ICityService cityService;
        private readonly IHouseService houseService;

        public HouseController(ICategoryService categoryService, IAgentService agentService, ICityService cityService, IHouseService houseService)
        {
            this.categoryService = categoryService;
            this.agentService = agentService;
            this.cityService = cityService;
            this.houseService = houseService;
        }


        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            // Todo: Implement this!
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isAgent = await this.agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new house!";

                return this.RedirectToAction("Become", "Agent");
            }

            HouseFormModel formModel = new HouseFormModel()
            {
                Categories = await this.categoryService.AllCategoryesAsync()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            bool isAgent = await this.agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to add new house!";

                return this.RedirectToAction("Become", "Agent");
            }

            bool categoryExist = await this.categoryService.ExistByIdAsync(model.CategoryId);

            if (!categoryExist)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category not exist!");
            }

            bool citiExist = await this.cityService.CityExistByNameAsync(model.CityName);

            if (!citiExist)
            {
                await this.cityService.CreateCityAsync(model.CityName);
            }
            
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoryesAsync();

                return this.View(model);
            }
            
            try
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
                int cityId = await this.cityService.GetCityId(model.CityName);

                await this.houseService.CreateHouseAsync(model, agentId!, cityId);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");
                model.Categories = await this.categoryService.AllCategoryesAsync();
                return this.View(model);
            }

            return this.RedirectToAction("All", "House");
        }
    }
}
