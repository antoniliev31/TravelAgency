namespace TravelAgency.Web.ViewModels.Hotel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Extensions.Options;

    public class ReservationInputModel
    {
        public Guid UserId { get; set; }

        public int HotelId { get; set; }

        public string SelectedRoomType { get; set; } = null!;

        public int CateringTypeId { get; set; }

        public int RoomTypeId { get; set; }

        public DateTime AccommodationDate { get; set; }

        public DateTime DepartureDate { get; set; }

        public int Days { get; set; }

        // Допълнителни свойства от HotelForReservationViewModel, които могат да се използват за валидации или изчисления
        public decimal DoubleRoomPrice { get; set; }

        public decimal StudioPrice { get; set; }

        public decimal ApartmentPrice { get; set; }

        // Допълнителни свойства, които да съдържат резултатите от валидациите и пресмятанията
        public decimal TotalPrice
        {
            get => CalculateTotalPrice();
        }

        // Метод за валидация на данните
        public bool Validate()
        {
            if (AccommodationDate < DateTime.Today || DepartureDate < DateTime.Today)
            {
                return false;
            }

            if (DepartureDate <= AccommodationDate)
            {
                return false;
            }

            return true;
        }

        // Метод за изчисление на общата цена
        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            if (RoomTypeId == 1) 
            {
                totalPrice = DoubleRoomPrice * Days;
            }
            else if (RoomTypeId == 2) 
            {
                totalPrice = StudioPrice * Days;
            }
            else if (RoomTypeId == 3) 
            {
                totalPrice = ApartmentPrice * Days;
            }


            return totalPrice;
        }
    }

}
