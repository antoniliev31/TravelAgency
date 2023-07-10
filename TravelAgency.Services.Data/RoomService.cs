namespace TravelAgency.Services.Data
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using Web.ViewModels.Room;

    public class RoomService : IRoomService
    {
        private readonly TravelAgencyDbContext dbContext;

        public RoomService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public async Task<IEnumerable<HotelSelectRoomFormModel>> AllRoomTypeAsync()
        {
            IEnumerable<HotelSelectRoomFormModel> allRoomTypes = await this.dbContext
                .RoomTypes
                .AsNoTracking()
                .Select(c => new HotelSelectRoomFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArrayAsync();

            return allRoomTypes;
        }

        public async Task<bool> ExistByIdAsync(int id)
        {
            bool result = await this.dbContext
                .RoomTypes
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public Task<IEnumerable<string>> AllRoomTypesNameAsync()
        {
            throw new NotImplementedException();
        }
    }
}
