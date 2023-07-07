using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Web.ViewModels.Agent;

namespace TravelAgency.Services.Data
{
    using Interfaces;

    public class AgentService : IAgentService
    {
        private readonly TravelAgencyDbContext dbContext;

        public AgentService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<bool> AgentExistByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
                .Agents
                .AnyAsync(a => a.UserId.ToString() == userId);

            return result;
        }

        public async Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber)
        {
            bool result = await this.dbContext
                .Agents
                .AnyAsync(a => a.PhoneNumber == phoneNumber);

            return result;
        }

        public async Task<bool> HasRentsByUserIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }

            return user.RentedHouses.Any();
        }

        public async Task CreateAgent(string userId, BecomeAgentFormModel model)
        {
            Agent newAgent = new Agent()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId)
            };

            await this.dbContext.Agents.AddAsync(newAgent);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
