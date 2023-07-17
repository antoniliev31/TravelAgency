namespace TravelAgency.Services.Data
{
    using System.Threading.Tasks;
    using Interfaces;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;
    using Web.ViewModels.Post;


    public class PostService : IPostService
    {
        private readonly TravelAgencyDbContext dbContext;

        public PostService(TravelAgencyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddPostAsync(PostFormModel post)
        {
            Post newPost = new Post
            {
                Content = post.Content,
                UserId = post.UserId,
                HotelId = post.HotelId
            };

            await this.dbContext.Posts.AddAsync(newPost);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
