﻿namespace TravelAgency.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class House
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AddressMinLength = 30;
            public const int AddressMaxLength = 150;

            public const int CityMinLength = 4;
            public const int CityMaxLength = 50;

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
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }

        public static class Post
        {
            public const int PostMinLength = 5;
            public const int PostMaxLength = 500;
        }
    }
}
