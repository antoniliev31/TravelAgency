namespace TravelAgency.Services.Data
{
    using Interfaces;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;

    public class ImageService : IImageService
    {
        private readonly TravelAgencyDbContext dbContext;

        public ImageService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddImagesAsync(List<string> imageUrls, int hotelId)
        {
            
            ICollection<Image> images = new List<Image>();

            for (int i = 0; i < imageUrls.Count; i++)
            {
                Image image = new Image
                {
                    ImageUrl = imageUrls[i],
                    IsMain = (i == 0),
                    HotelId = hotelId
                };

                images.Add(image);
            }

            await dbContext.Images.AddRangeAsync(images);
            await dbContext.SaveChangesAsync();
        }

        
    }
}
