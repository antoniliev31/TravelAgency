namespace TravelAgency.Common
{
    public static class EntityValidationConstants
    {
        public static class CateringType
        {
            public const int CateringNameMinLength = 2;
            public const int CateringNameMaxLength = 20;
        }

        public static class Hotel
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 50;

            public const int StarMinValue = 1;
            public const int StarMaxValue = 5;

            public const int SubTitleMinLength = 5;
            public const int SubTitleMaxLength = 150;

            public const int CityMinLength = 4;
            public const int CityMaxLength = 50;

            public const int CateringTypeMinLength = 1;
            public const int CateringTypeMaxLength = 5;

            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const int ImageUrlMaxLength = 2048;

            public const string PricePerMonthMinValue = "0";
            public const string PricePerMonthMaxValue = "2000";
            
        }

        public static class Agent
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class City
        {
            public const int CityMinLength = 5;
            public const int CityMaxLength = 50;
        }

        public static class Post
        {
            public const int PostMinLength = 5;
            public const int PostMaxLength = 500;
        }

        public static class RoomType
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 30;
        }

        public static class Category
        {
            public const int CategoryNameMinLength = 5;
            public const int CategoryNameMaxLength = 20;
        }

        public static class Image
        {
            public const int ImageMinLength = 10;
            public const int ImageMaxLength = 100;
        }
    }
}
