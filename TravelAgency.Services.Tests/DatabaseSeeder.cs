namespace TravelAgency.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Data;
    using TravelAgency.Data.Models;

    public class DatabaseSeeder
    {
        public static ApplicationUser User;
        
        public static void SeedDatabase(TravelAgencyDbContext dbContext)
        {
            User = new ApplicationUser
            {
                Id = new Guid("616D2E88-ADE3-44AE-BACA-2AE283747E52"),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEHmiB5uR1oqD9I2hfuUggkf2QC4GYTpvzI4iqY7pqZfLT+cmafn6btCBoSsDTCZX6g==",
                SecurityStamp = "d6cd7a62-b808-4f84-9da3-e24b9be6edfb",
                ConcurrencyStamp = "9d289e8b-75c6-485c-9fed-0de2511d9ee4",
                PhoneNumber = "0888888888",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                FirstName = "Ivan",
                LastName = "Ivanov",
                MyWishLists = null,
                MyOrders = null,
                MyPosts = null
            };
        }
    }
}
