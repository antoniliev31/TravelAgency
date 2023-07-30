namespace TravelAgency.Data.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IHotel
    {
        string Title { get; }
        string Location { get; }
    }
}
