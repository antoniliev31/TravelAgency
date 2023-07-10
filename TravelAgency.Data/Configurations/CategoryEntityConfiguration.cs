namespace TravelAgency.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategory());
        }

        private Category[] GenerateCategory()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;
            category = new Category()
            {
                Id = 1,
                Name = "Семеен хотел"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Хотел"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Апартхотел"
            };
            categories.Add(category);


            return categories.ToArray();
        }
    }
}
