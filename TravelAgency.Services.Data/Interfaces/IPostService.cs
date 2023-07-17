namespace TravelAgency.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelAgency.Data.Models;
    using TravelAgency.Web.ViewModels.Post;

    public interface IPostService
    {
        public Task AddPostAsync(PostFormModel post);
    }
}
