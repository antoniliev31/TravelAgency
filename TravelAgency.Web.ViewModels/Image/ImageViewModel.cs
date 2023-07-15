namespace TravelAgency.Web.ViewModels.Image
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ImageViewModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; } = null!;

        public bool IsMain { get; set; }
    }
}
