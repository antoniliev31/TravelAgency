namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using System;
   
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CateringTypeEntityConfiguration : IEntityTypeConfiguration<CateringType>
    {
        public void Configure(EntityTypeBuilder<CateringType> builder)
        {
            builder.HasData(this.GenerateCateringType());
        }

        private CateringType[] GenerateCateringType()
        {
            ICollection<CateringType> cateringTypes = new HashSet<CateringType>();

            CateringType cateringType;
            cateringType = new CateringType()
            {
                Id = 1,
                Name = "RoomOnly"
            };
            cateringTypes.Add(cateringType);

            cateringType = new CateringType()
            {
                Id = 2,
                Name = "BedAndBreakfast"
            };
            cateringTypes.Add(cateringType);

            cateringType = new CateringType()
            {
                Id = 3,
                Name = "HalfBoard"
            };
            cateringTypes.Add(cateringType);

            cateringType = new CateringType()
            {
                Id = 4,
                Name = "FullBoard"
            };
            cateringTypes.Add(cateringType);

            cateringType = new CateringType()
            {
                Id = 5,
                Name = "AllInclusive"
            };
            cateringTypes.Add(cateringType);

            return cateringTypes.ToArray();
        }
    }
}
