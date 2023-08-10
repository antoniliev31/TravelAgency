namespace TravelAgency.Services.Tests
{
    using TravelAgency.Data;
    using TravelAgency.Data.Models;

    public class DatabaseSeeder
    {
        public static ApplicationUser AdminUser;
        public static ApplicationUser User;
        
        public static void SeedDatabase(TravelAgencyDbContext dbContext)
        {
            AdminUser = new ApplicationUser
            {
                Id = Guid.Parse("949A14ED-2E82-4F5A-A684-A9C7E3CCB52E"),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEHmiB5uR1oqD9I2hfuUggkf2QC4GYTpvzI4iqY7pqZfLT+cmafn6btCBoSsDTCZX6g==",
                SecurityStamp = "d6cd7a62-b808-4f84-9da3-e24b9be6edfb",
                ConcurrencyStamp = "9d289e8b-75c6-485c-9fed-0de2511d9ee4",
                PhoneNumber = "+359888888888",
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

            User = new ApplicationUser
            {
                Id = Guid.Parse("6D5800CE-D726-4FC8-83D9-D6B3AC1F591E"),
                UserName = "user@user.com",
                NormalizedUserName = "USER@USER.com",
                Email = "user@user.com",
                NormalizedEmail = "user@user.com",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEH2//2ZcuRlxqxJQD7Qa4heiqFe31bAXf1ZJ4ZC26srUZMZrqyEVe9ZhukuMD5LuTw==",
                SecurityStamp = "8096988a-4873-4fad-8670-328647b26708",
                ConcurrencyStamp = "923fbd3a-1b6f-4ba6-8526-9dd58b0bdecb",
                PhoneNumber = "+359999999999",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                FirstName = "Georgi",
                LastName = "Georgiev",
                MyWishLists = null,
                MyOrders = null,
                MyPosts = null
            };

            dbContext.ApplicationUsers.Add(User);
            dbContext.ApplicationUsers.Add(AdminUser);

            //dbContext.SaveChanges();
        }
    }
}
