namespace TravelAgency.Services.Data.Interfaces
{
    using Web.ViewModels.Post;

    public interface IPostService
    {
        Task AddPostAsync(PostFormModel post);
    }
}
