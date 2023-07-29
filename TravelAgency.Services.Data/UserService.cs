namespace TravelAgency.Services.Data
{
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Web.ViewModels.User;

    public class UserService : IUserService
    {

        private readonly TravelAgencyDbContext dbContext;

        public UserService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<UserAllReservation>> AllUserReservationAsync(string id)
        {
            var allOrders = await this.dbContext
                .Orders
                .Where(o => o.UserId.ToString() == id)
                .Select(r => new UserAllReservation
                {
                    Id = 0,
                    Title = r.Hotel.Title,
                    ImageUrl = r.Hotel.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl ?? r.Hotel.Images.FirstOrDefault()!.ImageUrl,
                    Location = r.Hotel.Location.Name,
                    HotelId = r.HotelId,
                    Star = r.Hotel.Star,
                    Category = r.Hotel.Category.Name,
                    CateringType = r.Hotel.CateringType.Name,
                    RoomType = r.RoomType,
                    AccommodationDate = r.АccommodationDate,
                    DepartureDate = r.DepartureDate,
                    SelectedRoomType = r.RoomType,
                    NightsCount = r.Days,
                    TotalPrice = r.TotalPrice
                })
                .ToListAsync();

            return allOrders;
        }


    }
}
