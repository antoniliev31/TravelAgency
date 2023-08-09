namespace TravelAgency.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using Services.Data.Interfaces;
    using Web.ViewModels.User;

    using static Common.GeneralApplicationConstants;

    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("User/AllUsers")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> AllUsers()
        {
            IEnumerable<UserViewModel> users =
                this.memoryCache.Get<IEnumerable<UserViewModel>>(UserCacheKey);

            if (users == null)
            {
                users = await this.userService.AllUserAsync();

                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheDurationMinutes));

                this.memoryCache.Set(UserCacheKey, users, cacheOptions);
            }

            return View(users);
        }
    }
}
