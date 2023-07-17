namespace TravelAgency.Services.Data.Interfaces
{
    

    public interface IImageService
    {
        Task AddImagesAsync(List<string> imageUrls, int hotelId);
    }
}
