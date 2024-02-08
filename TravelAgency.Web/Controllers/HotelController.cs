namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Infrastructure.Extensions;
    using Microsoft.Extensions.Caching.Memory;
    using Services.Data.Models.House;
    using TravelAgency.Services.Data.Interfaces;
    using ViewModels.Hotel;
    using ViewModels.Post;

    using static Common.NotificationMessagesConstants;
    using static Common.GeneralApplicationConstants;
    using TravelAgency.Services.Data;
    using static TravelAgency.Common.EntityValidationConstants;

    [Authorize]
    public class HotelController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ILocationService locationService;
        private readonly IHotelService hotelService;
        private readonly ICateringService cateringService;
        private readonly IImageService imageService;
        private readonly IPostService postService;
        private readonly IWishService wishService;
        private readonly IUserService userService;
        private readonly IReservationService reservationService;

        private readonly IMemoryCache memoryCache;


        public HotelController(ICategoryService categoryService, 
            ILocationService locationService, IHotelService hotelService, 
            ICateringService cateringService, IWishService wishService, 
            IImageService imageService, IPostService postService, 
            IUserService userService, IMemoryCache memoryCache, IReservationService reservationService)
        {
            this.categoryService = categoryService;
            this.locationService = locationService;
            this.hotelService = hotelService;
            this.wishService = wishService;
            this.cateringService = cateringService;
            this.imageService = imageService;
            this.postService = postService;
            this.userService = userService;
            this.memoryCache = memoryCache;
            this.reservationService = reservationService;
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
            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be an admin to add new object!";

                return this.RedirectToAction("Index", "Home");
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
            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be an admin to add new object!";

                return this.RedirectToAction("Index", "Home");
            }

            bool categoryExist = await this.categoryService.ExistByIdAsync(model.CategoryId);

            if (!categoryExist)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Няма такава категория!!");
            }

            bool cateringExist = await this.cateringService.ExistByIdAsync(model.CategoryId);

            if (!cateringExist)
            {
                this.ModelState.AddModelError(nameof(model.CateringTypeId), "Няма такъв тъп изхранване!");
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
                int cityId = await this.locationService.GetLocationId(model.Location);

                int hotelId = await this.hotelService.CreateHotelAndReturnIdAsync(model, /*agentId!,*/ cityId);

                if (model.Images != null && model.Images.Any())
                {
                    await this.imageService.AddImagesAsync(model.Images, hotelId);
                }

                this.TempData[SuccessMessage] = "Хотелът беше добавен успешно!";

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
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
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

                this.TempData[ErrorMessage] = "Моля, въведете коментар!";
                return this.RedirectToAction("Details", new { id = id });
            }

            var currentUser = this.User.GetId()!;

            var hotelExists = await this.hotelService.HotelExistByIdAsync(id);
            if (!hotelExists)
            {
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
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
            this.TempData[SuccessMessage] = "Вие успешно публикувахте своя коментар!";
            return this.RedirectToAction("Details", new { id = id });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
                return this.RedirectToAction("All", "Hotel");
            }

            
            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must be an admin to edit hotel info";

                return this.RedirectToAction("Index", "Home");
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
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
                return this.RedirectToAction("All", "Hotel");
            }

            
            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an admin in order to edit hotel info";
                return this.RedirectToAction("Index", "Home");
            }

            
            try
            {
                await this.hotelService.EditHotelByIdAndFormModelAsync(id, model);
                model.Categories = await this.categoryService.AllCategoryesAsync();
                model.Caterings = await this.cateringService.AllCateringTypesAsync();
                this.TempData[SuccessMessage] = "Успешно променихте данните!";
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
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
                return this.RedirectToAction("All", "Hotel");
            }

            
            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an admin in order to edit hotel info";
                return this.RedirectToAction("Index", "Home");
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
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
                return this.RedirectToAction("All", "Hotel");
            }

            
            if (!this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "You must become an admin in order to edit hotel info";
                return this.RedirectToAction("Index", "Home");
            }

            
            try
            {
                await this.hotelService.DeleteHotelByIdAsync(id);

                this.TempData[WarningMessage] = "Успешно изтрихте този хотел!";
                return this.RedirectToAction("All", "Hotel");
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
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
                return this.RedirectToAction("All", "Hotel");
            }

            
            if (this.User.IsAdmin())
            {
                this.TempData[ErrorMessage] = "Не е редно сам да харесвате собствените си хотели!";
                return this.RedirectToAction("Details", "Hotel", new { id = id });
            }


            try
            {
                bool isHotelInWishList = await this.wishService.IsHotelInWishListAsync(id, userId);

                if (!isHotelInWishList)
                {
                    await this.wishService.AddHotelToWishListAsync(id, userId);
                    this.TempData[SuccessMessage] = "Вие добавихте този хотел в любими места!";
                }
                else
                {
                    await this.wishService.RemoveHotelFromWishListAsync(id, userId);
                    this.TempData[SuccessMessage] = "Вие премахнахте този хотел от любимите ви места!";
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
        public async Task<IActionResult> Wish()
        {
            
            string userId = this.User.GetId() ?? throw new InvalidOperationException("User not found.");
           
            try
            {
                IEnumerable<HotelAllViewModel> viewModel = await this.hotelService.AllWishHotelByUserAsync(userId);

                return View(viewModel);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";

                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Reservation(int id)
        {
            bool hotelExist = await this.hotelService.HotelExistByIdAsync(id);

            if (!hotelExist)
            {
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
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
                this.TempData[ErrorMessage] = "Не намерих такъв хотел!";
                return this.RedirectToAction("All", "Hotel");
            }

            if (viewModel.AccommodationDate >= viewModel.DepartureDate)
            {
                this.TempData[ErrorMessage] = "Неправилно избрани дати!";
                viewModel = await this.hotelService.GetHotelForReservationByAdAsync(id);
                return this.View(viewModel);
            }

            if (viewModel.SelectedRoomType == null)
            {
                this.TempData[ErrorMessage] = "Моля, изберете поне един вид стая!";
                viewModel = await this.hotelService.GetHotelForReservationByAdAsync(id);
                return this.View(viewModel);
            }


            try
            {
                await this.hotelService.AddReservation(id, viewModel, this.User.GetId()!);

                this.memoryCache.Remove(ReservationsCacheKey);

                return RedirectToAction("Order", "User");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";

                return RedirectToAction("Index", "Home");
            }
        }
        
        [HttpGet]
        public async Task<IActionResult> Cancel(int id)
        {
            bool reservationExist = await this.reservationService.ReservationExistById(id);

            if (!reservationExist)
            {
                this.TempData[ErrorMessage] = "Reservation with the provided id does not exist!";
                return this.RedirectToAction("Order", "User");
            }

            try
            {
                await reservationService.CancelReservationAsync(id);

                return RedirectToAction("Order", "User");
            }
            catch (Exception)
            {

                TempData[ErrorMessage] = "Unexpected error occurred! Please try again later!";
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
