namespace TravelAgency.Services.Data
{
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using Web.ViewModels.User;

    public class UserService : IUserService
    {

        private readonly TravelAgencyDbContext dbContext;

        public UserService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            ApplicationUser? user = await this.dbContext
                .ApplicationUsers
                .FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<List<UserAllReservationViewModel>> AllUserReservationAsync(string id)
        {
            var allOrders = await this.dbContext
                .Orders
                .Where(o => o.UserId.ToString() == id)
                .Select(r => new UserAllReservationViewModel
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
