namespace TravelAgency.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using Web.ViewModels.WishList;

    public class WishService : IWishService
    {
        private readonly TravelAgencyDbContext dbContext;

        public WishService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddHotelToWishListAsync(int hotelId, string userId)
        {
            var wish = new WishList
            {
                UserId = Guid.Parse(userId),
                HotelId = hotelId
            };

            this.dbContext.WishLists.Add(wish);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task RemoveHotelFromWishListAsync(int hotelId, string userId)
        {
            WishList? wish = await this.dbContext.WishLists
                .FirstOrDefaultAsync(w => w.HotelId == hotelId && w.UserId.ToString() == userId);

            if (wish != null)
            {
                this.dbContext.WishLists.Remove(wish);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> IsHotelInWishListAsync(int hotelId, string userId)
        {
            return await this.dbContext.WishLists
                .AnyAsync(w => w.HotelId == hotelId && w.UserId.ToString() == userId);
        }

    }
}
