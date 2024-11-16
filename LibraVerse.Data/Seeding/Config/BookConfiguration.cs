using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LibraVerse.Data.Models.Books;
using static LibraVerse.Common.EntityValidationConstants.Book;

namespace LibraVerse.Data.Seeding.Config
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //Fluent API

            builder.HasKey(b => b.Id);

            builder
                 .Property(b => b.Title)
                 .IsRequired()
                 .HasMaxLength(TitleMaxLength);

            builder
               .Property(b => b.Author)
               .IsRequired()
               .HasMaxLength(NameMaxLength);

            builder
                .Property(b => b.Genre)
                .IsRequired()
                .HasMaxLength(GenreMaxLength);

            builder
               .Property(b => b.Pages)
               .IsRequired()
               .HasMaxLength((int)BookPageMaxValue);

            builder
                .Property(b => b.Description)
                .IsRequired()
                .HasMaxLength(DescriptionMaxLength);

            builder.HasData(SeedBooks()); // To seed the base 
        }

        private List<Book> SeedBooks()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Title = "Лорд на клановете",
                    Author = "Кристи Голдън",
                    Genre = "Фентъзи",
                    ReleaseDate = new DateTime(2001, 10, 1),
                    Pages = 278,
                    Description = "Лорд на клановете разказва историята за възхода на вожд Трал към славата след краха на Ордата. Това е адаптация на отменената игра на Blizzard Warcraft Adventures: Lord of the Clans. Препубликуван е през 2016 г. за поредицата Blizzard Legends."
                },
                new Book()
                {
                    Title = "Българчета",
                    Author = "Ангел Каралийчев",
                    Genre = "Разкази и приказки за деца",
                    ReleaseDate = new DateTime(1942),
                    Pages = 192,
                    Description = "Сборникът от 1942 г. „Българчета“ ни въвежда в магическия свят на Каралийчев. Част от поместените истории се развиват във вълшебни и приказни страни, докато други са поучителни разкази от неговото съвремие.\r\n\r\nСъчетанието от мъдростта на народните притчи и художествения талант на автора правят книгата четиво, което няма как да не бъде харесано от малките читатели.\r\n\r\nЗащото без значение в каква епоха живеем, децата си остават деца, а основните морални ценности са непреходни."
                }
            };


            return books;
        }

    }
}
