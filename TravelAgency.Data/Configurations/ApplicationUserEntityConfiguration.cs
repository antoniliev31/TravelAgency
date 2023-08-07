﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Data.Models;

namespace TravelAgency.Data.Configurations
{
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder){
            
            builder.HasData(this.GenerateIdentityUser());
            builder.Property(u => u.FirstName)
                .HasDefaultValue("Test");
            builder.Property(u => u.LastName)
                .HasDefaultValue("Test");
        }

        private ApplicationUser[] GenerateIdentityUser()
        {
            ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

            ApplicationUser user;
            var hasher = new PasswordHasher<ApplicationUser>();

            user = new ApplicationUser()
            {
                Id = Guid.Parse("dea12856-c198-4129-b3f3-b893d8395082"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");
            
            users.Add(user);


            user = new ApplicationUser()
            {
                Id = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");

            users.Add(user);

            user = new ApplicationUser()
            {
                Id = Guid.Parse("949a14ed-2e82-4f5a-a684-a9c7e3ccb52e"),
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.com",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            user.PasswordHash = hasher.HashPassword(user, "123456");

            users.Add(user);

            return users.ToArray();
        }
    }
}
