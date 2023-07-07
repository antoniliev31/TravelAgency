namespace TravelAgency.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using ViewModels.Agent;
    using TravelAgency.Services.Data.Interfaces;
    using Infrastructure.Extensions;
    
    using static Common.NotificationMessagesConstants;

    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService agentService)
        {
            this.agentService = agentService;
        }


        [HttpGet]
        public async Task<IActionResult> Become()
        {
            string? userId = this.User.GetId();

            bool isAgent = await this.agentService.AgentExistByUserIdAsync(userId);

            if (isAgent)
            {
                this.TempData[ErrorMessage] = "You are already an agent!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            string? userId = this.User.GetId();

            bool isAgent = await this.agentService.AgentExistByUserIdAsync(userId);

            if (isAgent)
            {
                this.TempData[ErrorMessage] = "You are already an agent!";

                return this.RedirectToAction("Index", "Home");
            }

            bool isPhoneNumberTaken = await this.agentService
                .AgentExistsByPhoneNumberAsync(model.PhoneNumber);

            if (isPhoneNumberTaken)
            {
                this.ModelState.AddModelError(nameof(model.PhoneNumber), "Agent with the provided number already exist!");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool userHasActiveRents = await this.agentService
                .HasRentsByUserIdAsync(userId);

            if (userHasActiveRents)
            {
                this.TempData[ErrorMessage] = "Yon must not have any active rents in order to become an agent!";

                return this.RedirectToAction("Mine", "Home");
            }

            try
            {
                await this.agentService.CreateAgent(userId, model);
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] =
                    "Unexpected error occurred while registering you as an agent! Please try again later or contact administrator!";

                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("All", "House");

        }
    }
}
