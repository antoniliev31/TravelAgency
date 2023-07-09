namespace TravelAgency.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelAgency.Web.ViewModels.House;

    public interface ICityService 
    {
        Task<bool> CityExistByNameAsync(string cityName);

        Task CreateCityAsync(string cityName);

        Task<int> GetCityId(string cityName);

        Task<IEnumerable<string>> AllCityNamesAsync();
    }
}
