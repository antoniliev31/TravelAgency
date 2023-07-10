namespace TravelAgency.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelAgency.Web.ViewModels.House;

    public interface ILocationService 
    {
        Task<bool> LocationExistByNameAsync(string locationName);

        Task CreateLocationAsync(string locationName);

        Task<int> GetLocationId(string cityName);

        Task<IEnumerable<string>> AllLocationNamesAsync();
    }
}
