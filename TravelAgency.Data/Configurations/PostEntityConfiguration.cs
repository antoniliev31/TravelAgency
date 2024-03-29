﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Data.Models;

namespace TravelAgency.Data.Configurations
{
    public class PostEntityConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder
                .HasOne(p => p.ApplicationUser)
                .WithMany(u => u.MyPosts)
                .HasForeignKey(p => p.UserId);

            builder
                .HasOne(p => p.Hotel)
                .WithMany(h => h.Posts)
                .HasForeignKey(p => p.HotelId);

            builder.HasData(this.GeneratePosts());
        }

        private Post[] GeneratePosts()
        {
            ICollection<Post> posts = new HashSet<Post>();

            Post post;
            post = new Post
            {
                Id = 1,
                Content = "Прекрасно преживяване в хотела! Уютна стая, отлично обслужване и изискан ресторант. Няма как да не се чувстваш приветливо посрещнат и релаксиран. Препоръчвам",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 1
            };
            posts.Add(post);


            post = new Post
            {
                Id = 2,
                Content = "Къщата за гости беше просто превъзходна! Прекарахме незабравим уикенд сред природата, в компанията на любезни домакини. Всичко беше перфектно - от удобствата до гледката. С удоволствие ще се върнем отново!",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 2
            };
            posts.Add(post);

            post = new Post
            {
                Id = 3,
                Content = "Невероятно преживяване в този хотел. Спокойствие, лукс и безупречно обслужване. От момента на пристигането до заминаването си се чувствахме като VIP гости. Благодарим на персонала за прекрасния престой!",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 3
            };
            posts.Add(post);

            post = new Post
            {
                Id = 4,
                Content = "Хотелът ни очарова с уникален дизайн и стил. Всяка детайлна измислица беше внимателно изпълнена. Спяхме в комфортен легловия аранжимент и се насладихме на изисканата храна. Подгответе се за неповторимо изживяване!",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 4
            };
            posts.Add(post);

            post = new Post
            {
                Id = 5,
                Content = "Къщата за гости беше уютна и пълна със сърце и душа. Гостоприемните домакини ни посрещнаха с топлина и готвената храна беше вкусна и автентична. Проведохме спокоен и релаксиращ уикенд в прекрасна обстановка.",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 5
            };
            posts.Add(post);

            post = new Post
            {
                Id = 6,
                Content = "Семейният ни престой в този хотел беше мечтан. Басейнът и игралната зала развълнуваха децата, докато спа-центърът ни предложи наистина релаксиращ опит. Отлична комбинация от забавление и отдих!",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 6
            };
            posts.Add(post);

            post = new Post
            {
                Id = 7,
                Content = "Избрахме тази къща за гости за нашата романтична почивка и не бихме могли да бъдем по-щастливи. Атмосферата беше магична, а гледката от терасата буквално откъсна дъха. Ще я препоръчаме на всички!",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 1
            };
            posts.Add(post);

            post = new Post
            {
                Id = 8,
                Content = "Хотелът беше прекрасно решение за нашия семеен отдих. Паркът и детските площадки зарадваха децата, а ресторантът ни предложи невероятни вкусове. Прекарахме незабравимо време с любимите си хора.",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 2
            };
            posts.Add(post);

            post = new Post
            {
                Id = 9,
                Content = "Невероятна къща за гости, вложена със стил и комфорт. Пълноценното оборудване и уютната атмосфера ни позволиха да се отпуснем напълно. Прекарахме прекрасна почивка сред природата.",
                UserId = Guid.Parse("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                HotelId = 3
            };
            posts.Add(post);


            return posts.ToArray();
        }
    }
    
}
