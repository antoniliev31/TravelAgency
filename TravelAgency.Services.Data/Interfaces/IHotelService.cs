namespace TravelAgency.Services.Data.Interfaces
{
    using Models.House;
    using Web.ViewModels.Home;
    using Web.ViewModels.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeAddedHotelAsync();

        Task<int> CreateHotelAsync(HotelFormModel formModel, string agentId, int locationId);

        Task<AllHotelsFilteredAndPagesServiceModel> AllHotelAsync(AllHotelQueryModel queryModel);

        Task<IEnumerable<HotelAllViewModel>> AllHotelByAgentIdAsync(string agentId);

        Task<HotelDetailsViewModel?> GetHotelDetailsByAdAsync(int hotelId);

        Task<IEnumerable<int>> AllStarsAsync();

        Task<bool> HotelExistByIdAsync(int hotelId);

        Task<HotelFormModel> GetHotelForEditByIdAsync(int hotelId);

        Task<bool> IsAgentWithIdOwnerOfHotelWithIdAsync(int hotelId, string agentId);

        Task EditHotelByIdAndFormModelAsync(int hotelId, HotelFormModel model);
    }

}
