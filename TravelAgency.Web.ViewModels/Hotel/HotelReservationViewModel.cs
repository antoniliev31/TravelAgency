namespace TravelAgency.Web.ViewModels.Hotel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TravelAgency.Web.ViewModels.Category;
    using TravelAgency.Web.ViewModels.Catering;

    public class HotelReservationViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Locatioin { get; set; } = null!;

        public int Star { get; set; }

        public string Category { get; set; }

        public string CateringType { get; set; }

        public List<string> RoomTypes { get; set; }

        [Display(Name = "Дата на настаняване")]
        [DataType(DataType.Date)]
        public DateTime АccommodationDate { get; set; }

        [Display(Name = "Дата на напускане")]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        public decimal DoubleRoomPrice { get; set; }

        public decimal StudioPrice { get; set; }

        public decimal ApartmentPrice { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (АccommodationDate == null || DepartureDate == null)
            {
                yield return ValidationResult.Success;
            }

            DateTime accommodationDate;
            DateTime departureDate;

            if (DateTime.TryParse(АccommodationDate.ToString(), out accommodationDate) &&
                DateTime.TryParse(DepartureDate.ToString(), out departureDate))
            {
                DateTime minDate = DateTime.Today;
                DateTime maxDate = DateTime.Today.AddYears(1);

                if (accommodationDate < minDate || departureDate < minDate || departureDate > maxDate)
                {
                    yield return new ValidationResult("Невалидни дати. Моля, проверете дали датите са в рамките на една година напред.");
                }

                if (departureDate <= accommodationDate)
                {
                    yield return new ValidationResult("Дата на напускане трябва да бъде след датата на настаняване.");
                }
            }
            else
            {
                yield return new ValidationResult("Невалидни дати.");
            }
        }
    }
}
