namespace TravelAgency.Data.Configurations
{
    using System;
    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class OrderListEntityConfiguration : IEntityTypeConfiguration<OrderList>
    {
        public void Configure(EntityTypeBuilder<OrderList> builder)
        {
            builder
                .HasOne(o => o.ApplicationUser)
                .WithMany(u => u.MyOrders)
                .HasForeignKey(o => o.UserId);

            builder
                .HasOne(o => o.Hotel)
                .WithMany(h => h.OrderLists)
                .HasForeignKey(o => o.HotelId);
        }
    }
}
