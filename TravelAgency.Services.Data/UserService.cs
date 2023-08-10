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

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            ApplicationUser? user = await this.dbContext
                .ApplicationUsers
                .FirstOrDefaultAsync(u => u.Id.ToString().ToLower() == userId.ToLower());

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<IEnumerable<UserViewModel>> AllUserAsync()
        {
            List<UserViewModel> allUsers = new List<UserViewModel>();

            IEnumerable<UserViewModel> users = await this.dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.PhoneNumber
                })
                .ToArrayAsync();

            allUsers.AddRange(users);

            return allUsers;
        }

        public async Task<List<UserAllReservationViewModel>> AllUserReservationAsync(string id)
        {
            var allOrders = await this.dbContext
                .Orders
                .Where(o => o.UserId.ToString().ToUpper() == id.ToUpper())
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
