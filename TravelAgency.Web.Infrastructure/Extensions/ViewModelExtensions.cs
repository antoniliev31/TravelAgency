namespace TravelAgency.Web.Infrastructure.Extensions
{
    using System.Text.RegularExpressions;
    using ViewModels.Interfaces;

    public static class ViewModelExtensions
    {
        public static string GetInformation(this IHotelModel hotel)
        {
            return hotel.Title.Replace(" ", "-") + "-" + GetLocation(hotel.Location);
        }

        private static string GetLocation(string location)
        {
            location = String.Join("-", location.Split(" ").Take(3));
            return Regex.Replace(location, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
