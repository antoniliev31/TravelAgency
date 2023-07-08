namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.House;
    using Web.ViewModels.Home;

    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHouseAsync();

        Task CreateHouseAsync(HouseFormModel formModel, string agentId, int cityId);


        //Task<IEnumerable<IndexViewModel>> LastThreeCommentAsync();
    }

}
