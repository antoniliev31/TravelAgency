namespace TravelAgency.Services.Data.Interfaces
{
    using Models.House;
    using Web.ViewModels.Home;
    using Web.ViewModels.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeAddedHotelAsync();

        Task CreateHotelAsync(HotelFormModel formModel, string agentId, int locationId);

        Task<AllHotelsFilteredAndPagesServiceModel> AllHotelAsync(AllHotelQueryModel queryModel);

        Task<IEnumerable<HotelAllViewModel>> AllHotelByAgentIdAsync(string agentId);

        Task<IEnumerable<HotelAllViewModel>> AllWishHotelByUserAsync(string userId);

        Task<IEnumerable<HotelAllViewModel>> AllOrderHotelByUserAsync(string userId);

        Task<HotelDetailsViewModel?> GetHotelDetailsByAdAsync(string hotelId);


    }

}
