using System.Reflection;
using Microsoft.AspNetCore.Identity;
using TravelAgency.Data.Models;

namespace TravelAgency.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class TravelAgencyDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<House> Houses { get; set; } = null!;

        public DbSet<Agent> Agents { get; set; } = null!;

        public DbSet<City> Cities { get; set; } = null!;

        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(TravelAgencyDbContext)) ?? 
                                      Assembly.GetExecutingAssembly();


            builder.ApplyConfigurationsFromAssembly(configAssembly);
            
            base.OnModelCreating(builder);
        }
    }
}