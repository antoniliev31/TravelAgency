namespace TravelAgency.Services.Data.Interfaces
{
    using Models.House;
    using Web.ViewModels.Home;
    using Web.ViewModels.Hotel;

    public interface IHotelService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeAddedHotelAsync();

        Task<int> CreateHotelAndReturnIdAsync(HotelFormModel formModel, int locationId);

        Task<AllHotelsFilteredAndPagesServiceModel> AllHotelAsync(AllHotelQueryModel queryModel);

        Task<HotelDetailsViewModel?> GetHotelDetailsByAdAsync(int hotelId);

        Task<IEnumerable<int>> AllStarsAsync();

        Task<bool> HotelExistByIdAsync(int hotelId);

        Task<HotelFormModel> GetHotelForEditByIdAsync(int hotelId);

        Task EditHotelByIdAndFormModelAsync(int hotelId, HotelFormModel model);

        Task<HotelForDeleteViewModel> GetHotelForDeleteByIdAsync(int hotelId);

        Task DeleteHotelByIdAsync(int hotelId);

        Task<HotelForReservationViewModel> GetHotelForReservationByAdAsync(int hotelId);

        Task AddReservation(int id, HotelForReservationViewModel viewModel, string userId);
    }

}
