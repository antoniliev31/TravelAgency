namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.Agent;

    public interface IAgentService
    {
        Task<bool> AgentExistByUserIdAsync(string userId);

        Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber);

        Task<bool> HasRentsByUserIdAsync(string userId);

        Task CreateAgentAsync(string userId, BecomeAgentFormModel model);

        Task<string?> GetAgentIdByUserIdAsync(string userId);
    }
}
