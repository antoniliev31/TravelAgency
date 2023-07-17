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
            
            //var images = imageUrls
            //    .Select((imageUrl, index) => new Image
            //{
            //    ImageUrl = imageUrl,
            //    IsMain = (index == 0), // Първата снимка е главна
            //    HotelId = hotelId
            //}).ToList();

            ICollection<Image> images = new List<Image>();

            for (int i = 0; i < imageUrls.Count; i++)
            {
                Image image = new Image
                {
                    ImageUrl = imageUrls[i],
                    IsMain = (i == 0), // Първата снимка е главна
                    HotelId = hotelId
                };

                images.Add(image);
            }

            await dbContext.Images.AddRangeAsync(images);
            await dbContext.SaveChangesAsync();
        }

        
    }
}
