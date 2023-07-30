namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Infrastructure.Extensions;
    using Services.Data.Models.House;
    using TravelAgency.Services.Data.Interfaces;
    using ViewModels.Hotel;
    using ViewModels.Post;
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class HotelController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;
        private readonly ILocationService locationService;
        private readonly IHotelService hotelService;
        private readonly ICateringService cateringService;
        private readonly IImageService imageService;
        private readonly IPostService postService;
        private readonly IWishService wishService;
        

        public HotelController(ICategoryService categoryService, IAgentService agentService, ILocationService locationService, IHotelService hotelService, ICateringService cateringService, IWishService wishService, IImageService imageService, IPostService postService)
        {
            this.categoryService = categoryService;
            this.agentService = agentService;
            this.locationService = locationService;
            this.hotelService = hotelService;
            this.wishService = wishService;
            this.cateringService = cateringService;
            this.imageService = imageService;
            this.postService = postService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllHotelQueryModel queryModel)
        {
            AllHotelsFilteredAndPagesServiceModel serviceModel = await this.hotelService.AllHotelAsync(queryModel);

            queryModel.Hotels = serviceModel.Hotels;
            queryModel.TotalHotels = serviceModel.TotalHotelsCount;
            queryModel.Categories = await this.categoryService.AllCategoryNamesAsync();
            queryModel.Locations = await this.locationService.AllLocationNamesAsync();
            queryModel.Stars = await this.hotelService.AllStarsAsync();
            
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

            bool locationExist = await this.locationService.LocationExistByNameAsync(model.Location);

            if (!locationExist)
            {
                await this.locationService.CreateLocationAsync(model.Location);
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoryesAsync();
                model.Caterings = await this.cateringService.AllCateringTypesAsync();

                return this.View(model);
            }

            try
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

                int cityId = await this.locationService.GetLocationId(model.Location);

                int hotelId = await this.hotelService.CreateHotelAndReturnIdAsync(model, agentId!, cityId);

                if (model.Images != null && model.Images.Any())
                {
                    await this.imageService.AddImagesAsync(model.Images, hotelId);
                }
                
                this.TempData[SuccessMessage] = "Hotel was added successfully!";
                
                return this.RedirectToAction("Details", "Hotel", new { id = hotelId });

            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to add your new house! Please try again later or contact administrator!");
                model.Categories = await this.categoryService.AllCategoryesAsync();
                model.Caterings = await this.cateringService.AllCateringTypesAsync();
                return this.View(model);
            }

        }
        

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            List<HotelAllViewModel> myHotel = new List<HotelAllViewModel>();

            string userId = this.User.GetId()!;

            bool isUserAgent = await this.agentService.AgentExistByUserIdAsync(userId);

            if (isUserAgent)
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId);

                myHotel.AddRange(await this.hotelService.AllHotelByAgentIdAsync(agentId!));
            }

            return this.View(myHotel);
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }

            try
            {
                HotelDetailsViewModel? viewModel = await this.hotelService.GetHotelDetailsByAdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";

                return RedirectToAction("Index", "Home");
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddComment(int id, string comment)
        {
            if (string.IsNullOrEmpty(comment))
            {
                
                this.TempData[ErrorMessage] = "Please enter a comment.";
                return this.RedirectToAction("Details", new { id = id });
            }

            var currentUser = this.User.GetId()!;
            
            var hotelExists = await this.hotelService.HotelExistByIdAsync(id);
            if (!hotelExists)
            {
                this.TempData[ErrorMessage] = "Hotel not found.";
                return this.RedirectToAction("All");
            }

            if (this.ModelState.IsValid)
            {
                var post = new PostFormModel()
                {
                    Content = comment,
                    UserId = Guid.Parse(currentUser),
                    HotelId = id
                };
                await this.postService.AddPostAsync(post);
            }
            this.TempData[SuccessMessage] = "You have successfully posted your comment.";
            return this.RedirectToAction("Details", new { id = id });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }

            bool isUserAgent = await this.agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit hotel info";

                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.hotelService.IsAgentWithIdOwnerOfHotelWithIdAsync(id, agentId!);

            if (!isAgentOwner)
            {
                this.TempData[ErrorMessage] = "You must br the agent owner of the hotel yoy want to edit!";

                return this.RedirectToAction("Mine", "Hotel");
            }
            
            try
            {
                HotelFormModel formModel = await this.hotelService.GetHotelForEditByIdAsync(id);

                formModel.Categories = await this.categoryService.AllCategoryesAsync();
                formModel.Caterings = await this.cateringService.AllCateringTypesAsync();

                return this.View(formModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";
                
                return RedirectToAction("Index", "Home");
            }
            
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, HotelFormModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoryesAsync();
                model.Caterings = await this.cateringService.AllCateringTypesAsync();
                return this.View(model);
            }

            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }

            bool isUserAgent = await this.agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit hotel info";
                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.hotelService.IsAgentWithIdOwnerOfHotelWithIdAsync(id, agentId!);

            if (!isAgentOwner)
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the hotel you want to edit!";
                return this.RedirectToAction("Mine", "Hotel");
            }

            try
            {
                await this.hotelService.EditHotelByIdAndFormModelAsync(id, model);
                model.Categories = await this.categoryService.AllCategoryesAsync();
                model.Caterings = await this.cateringService.AllCateringTypesAsync();
                this.TempData[SuccessMessage] = "Hotel was edited successfully!";
                return this.RedirectToAction("Details", "Hotel", new { id = id });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error! Please try again later.");
            }

            return this.RedirectToAction("Details", "Hotel", new { id = id });
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }

            bool isUserAgent = await this.agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit hotel info";
                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.hotelService.IsAgentWithIdOwnerOfHotelWithIdAsync(id, agentId!);

            if (!isAgentOwner)
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the hotel you want to edit!";
                return this.RedirectToAction("Mine", "Hotel");
            }

            try
            {
                HotelForDeleteViewModel viewModel = await this.hotelService.GetHotelForDeleteByIdAsync(id);

                return this.View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";
                return this.RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, HotelForDeleteViewModel model)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }

            bool isUserAgent = await this.agentService.AgentExistByUserIdAsync(this.User.GetId()!);

            if (!isUserAgent)
            {
                this.TempData[ErrorMessage] = "You must become an agent in order to edit hotel info";
                return this.RedirectToAction("Become", "Agent");
            }

            string? agentId = await this.agentService.GetAgentIdByUserIdAsync(this.User.GetId()!);

            bool isAgentOwner = await this.hotelService.IsAgentWithIdOwnerOfHotelWithIdAsync(id, agentId!);

            if (!isAgentOwner)
            {
                this.TempData[ErrorMessage] = "You must be the agent owner of the hotel you want to edit!";
                return this.RedirectToAction("Mine", "Hotel");
            }

            try
            {
                await this.hotelService.DeleteHotelByIdAsync(id);

                this.TempData[WarningMessage] = "The hotel was successfully deleted!";
                return this.RedirectToAction("Mine", "Hotel");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";
                return this.RedirectToAction("Delete", "Hotel", new { id = id });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Wish(int id)
        {
            string userId = this.User.GetId() ?? throw new InvalidOperationException("User not found.");

            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }
            
            bool isUserAgent = await this.agentService.AgentExistByUserIdAsync(userId);

            if (isUserAgent)
            {
                string? agentId = await this.agentService.GetAgentIdByUserIdAsync(userId)!;
                bool isAgentOwner = await this.hotelService.IsAgentWithIdOwnerOfHotelWithIdAsync(id, agentId);

                if (isAgentOwner)
                {
                    this.TempData[ErrorMessage] = "You can't like your own hotels!";
                    return this.RedirectToAction("Details", "Hotel", new { id = id });
                }
            }

            try
            {
                bool isHotelInWishList = await this.wishService.IsHotelInWishListAsync(id, userId);

                if (!isHotelInWishList)
                {
                    await this.wishService.AddHotelToWishListAsync(id, userId);
                    this.TempData[SuccessMessage] = "You have successfully liked this hotel!";
                }
                else
                {
                    await this.wishService.RemoveHotelFromWishListAsync(id, userId);
                    this.TempData[SuccessMessage] = "You have successfully removed this hotel!";
                }

                return this.RedirectToAction("Details", "Hotel", new { id = id });
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";
                return this.RedirectToAction("Details", "Hotel", new { id = id });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Reservation(int id)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }

            try
            {
                HotelForReservationViewModel? viewModel = await this.hotelService.GetHotelForReservationByAdAsync(id);
                return this.View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";

                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Reservation(int id, HotelForReservationViewModel viewModel)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Hotel with the provided id does not exist!";
                return this.RedirectToAction("All", "Hotel");
            }

            try
            {
                await this.hotelService.AddReservation(id, viewModel, this.User.GetId()!);

                return RedirectToAction("Order", "User");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";

                return RedirectToAction("Index", "Home");
            }
        }



        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";
            return this.RedirectToAction("Index", "Home");
        }

        
    }
}
