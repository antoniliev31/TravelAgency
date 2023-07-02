namespace TravelAgency.Services.Data.Interfaces
{
    using TravelAgency.Web.ViewModels.Home;

    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHouseAsync();
    }

}
