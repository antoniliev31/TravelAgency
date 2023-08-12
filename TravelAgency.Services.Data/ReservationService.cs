namespace TravelAgency.Services.Data
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using Web.ViewModels.Reservation;
    using static TravelAgency.Common.EntityValidationConstants;

    public class ReservationService : IReservationService
    {
        private readonly TravelAgencyDbContext dbContext;

        public ReservationService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<IEnumerable<ReservationViewModel>> AllAsync()
        {
            IEnumerable<ReservationViewModel> allReservation = await this.dbContext
                .Orders
                .Include(h => h.Hotel)
                .Include(h => h.ApplicationUser)
                .Select(h => new ReservationViewModel()
                {
                    Title = h.Hotel.Title,
                    ImageUrl = h.Hotel.Images.FirstOrDefault(i => i.IsMain)!.ImageUrl,
                    UserFullName = h.ApplicationUser.FirstName + " " + h.ApplicationUser.LastName,
                    UserEmail = h.ApplicationUser.Email,
                    UserPhoneNumber = h.ApplicationUser.PhoneNumber ?? "n/a",
                    AccommodationDate = h.АccommodationDate.Date,
                    DepartureDate = h.DepartureDate.Date,
                    Days = h.Days,
                    Price = h.Price,
                    TotalPrice = h.TotalPrice

                })
                .ToListAsync();

            return allReservation;
        }

        public async Task CancelReservationAsync(int reservationId)
        {
            Order order = (await this.dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == reservationId))!;

            this.dbContext.Orders.Remove(order);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> ReservationExistById(int id)
        {
            bool result = await this.dbContext
            .Orders
                .AnyAsync(a => a.Id == id);

            return result;
        }
    }
}
