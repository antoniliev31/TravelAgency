namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class WishListEntityConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(w => w.ApplicationUser)
                .WithMany(u => u.MyWishLists)
                .HasForeignKey(w => w.UserId);

            builder
                .HasOne(w => w.Hotel)
                .WithMany(h => h.WishLists)
                .HasForeignKey(w => w.HotelId);

            //builder.HasData(this.GeneratePosts());

        }
    }
}
