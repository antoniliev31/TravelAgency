namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(i => i.Id);

            builder
                .HasOne(i => i.Hotel)
                .WithMany(h => h.Images)
                .HasForeignKey(i => i.HotelId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(i => i.IsMain)
                .HasDefaultValue(false);

            builder.HasData(this.GenerateImages());

        }

        private Image[] GenerateImages()
        {
            ICollection<Image> images = new HashSet<Image>();

            Image image;

            // Laguna Beach

            image = new Image
            {
                Id = 5,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/IMG_4383.jpg",
                IsMain = true,
                HotelId = 1
            };

            images.Add(image);

            image = new Image
            {
                Id = 6,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/IMG_4543.jpg",
                HotelId = 1
            };

            images.Add(image);

            image = new Image
            {
                Id = 7,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4025.jpg",
                HotelId = 1
            };

            images.Add(image);

            image = new Image
            {
                Id = 8,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4026.jpg",
                HotelId = 1
            };

            images.Add(image);

            image = new Image
            {
                Id = 9,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/149/big/CRW_4033.jpg",
                HotelId = 1
            };

            images.Add(image);


            // Tabanov Beach

            image = new Image
            {
                Id = 10,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/RXES.jpg",
                IsMain = true,
                HotelId = 2
            };

            images.Add(image);

            image = new Image
            {
                Id = 11,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0686.JPG",
                HotelId = 2
            };

            images.Add(image);

            image = new Image
            {
                Id = 12,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0676.JPG",
                HotelId = 2
            };

            images.Add(image);

            image = new Image
            {
                Id = 13,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0672.JPG",
                HotelId = 2
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 14,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/8/big/DSC_0685.JPG",
                HotelId = 2
            };

            images.Add(image);



            // Apolis

            image = new Image
            {
                Id = 15,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/B7NF.jpg",
                IsMain = true,
                HotelId = 3
            };

            images.Add(image);

            image = new Image
            {
                Id = 16,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/Z4Y7.jpg",
                HotelId = 3
            };

            images.Add(image);

            image = new Image
            {
                Id = 17,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/DSC_0114.JPG",
                HotelId = 3
            };

            images.Add(image);

            image = new Image
            {
                Id = 18,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/DSC_0115.JPG",
                HotelId = 3
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 19,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8130/7/big/58MB.jpg",
                HotelId = 3
            };

            images.Add(image);


            // ApoliniaRezort

            image = new Image
            {
                Id = 20,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000721.JPG",
                IsMain = true,
                HotelId = 4
            };

            images.Add(image);

            image = new Image
            {
                Id = 21,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000761.JPG",
                HotelId = 4
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 22,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000760.JPG",
                HotelId = 4
            };

            images.Add(image);

            image = new Image
            {
                Id = 23,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000736.JPG",
                HotelId = 4
            };

            images.Add(image);

            image = new Image
            {
                Id = 24,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel///136/big/P1000718.JPG",
                HotelId = 4
            };

            images.Add(image);



            // Arkutino Family Resort

            image = new Image
            {
                Id = 25,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0826.JPG",
                IsMain = true,
                HotelId = 5
            };

            images.Add(image);

            image = new Image
            {
                Id = 26,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/P8270161.JPG",
                HotelId = 5
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 27,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/P8270157.JPG",
                HotelId = 5
            };

            images.Add(image);

            image = new Image
            {
                Id = 28,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0883.JPG",
                HotelId = 5
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 29,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG//67/big/DSC_0882.JPG",
                HotelId = 5
            };

            images.Add(image);


            // Atia Rezort
            
            image = new Image
            {
                Id = 30,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/1.jpg",
                IsMain = true,
                HotelId = 6
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 31,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7398.jpg",
                HotelId = 6
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 32,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7250.jpg",
                HotelId = 6
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 33,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/_MG_7275.jpg",
                HotelId = 6
            };

            images.Add(image);
            
            image = new Image
            {
                Id = 34,
                ImageUrl = "https://store.crs.bg/seastar-2016/img_hotel/BG/8142/130/big/3.jpg",
                HotelId = 6
            };

            images.Add(image);
            


            return images.ToArray();
        }
    }
}
