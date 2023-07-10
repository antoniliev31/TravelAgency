namespace TravelAgency.Services.Data.Interfaces
{
    using Models.House;
    using Web.ViewModels.House;
    using Web.ViewModels.Home;
    using Web.ViewModels.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHouseAsync();

        Task CreateHotelAsync(HotelFormModel formModel, string agentId, int locationId);

        Task<AllHotelsFilteredAndPagesServiceModel> AllAsync(AllHotelQueryModel queryModel);


        //Task<IEnumerable<IndexViewModel>> LastThreeCommentAsync();
    }

}
