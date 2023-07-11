namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Infrastructure.Extensions;
    using Services.Data.Models.House;
    using TravelAgency.Services.Data.Interfaces;
    using ViewModels.Hotel;
    using ViewModels.House;

    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class HotelController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;
        private readonly ILocationService locationService;
        private readonly IHotelService hotelService;
        private readonly ICateringService cateringService;
        private readonly IRoomService roomService;

        public HotelController(ICategoryService categoryService, IAgentService agentService, ILocationService locationService, IHotelService hotelService, ICateringService cateringService, IRoomService roomService)
        {
            this.categoryService = categoryService;
            this.agentService = agentService;
            this.locationService = locationService;
            this.hotelService = hotelService;
            this.roomService = roomService;
            this.cateringService = cateringService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllHotelQueryModel queryModel)
        {
            AllHotelsFilteredAndPagesServiceModel serviceModel =
                await this.hotelService.AllAsync(queryModel);

            queryModel.Hotels = serviceModel.Hotels;
            queryModel.TotalHotels = serviceModel.TotalHotelsCount;
            queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();
            queryModel.Locations = await this.locationService.AllLocationNamesAsync();
            // Todo Room
            // Todo Catering


            return this.View(queryModel);
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

            HotelFormModel formModel = new HotelFormModel()
            {
                Categories = await this.categoryService.AllCategoryesAsync(),
                Caterings = await this.cateringService.AllCateringTypesAsync(),
                Rooms = await this.roomService.AllRoomTypeAsync()
            };

            return View(formModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HotelFormModel model)
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

            bool cateringExist = await this.cateringService.ExistByIdAsync(model.CategoryId);

            if (!cateringExist)
            {
                this.ModelState.AddModelError(nameof(model.CateringTypeId), "Selected catering type not exist!");
            }

            bool roomExist = await this.roomService.ExistByIdAsync(model.RoomTypeId);

            if (!roomExist)
            {
                this.ModelState.AddModelError(nameof(model.RoomTypeId), "Selected room type not exist!");
            }

            bool locationExist = await this.locationService.LocationExistByNameAsync(model.Location);

            if (!locationExist)
            {
                await this.locationService.CreateLocationAsync(model.Location);
            }
            
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoryesAsync();
                model.Caterings = await this.cateringService.AllCateringTypesAsync();
                model.Rooms = await this.roomService.AllRoomTypeAsync();

                return this.View(model);
            }
            
            try
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);
                int cityId = await this.locationService.GetLocationId(model.Location);

                await this.hotelService.CreateHotelAsync(model, agentId!, cityId);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");
                model.Categories = await this.categoryService.AllCategoryesAsync();
                model.Caterings = await this.cateringService.AllCateringTypesAsync();
                model.Rooms = await this.roomService.AllRoomTypeAsync();
                return this.View(model);
            }

            return this.RedirectToAction("All", "Hotel");
        }
    }
}
