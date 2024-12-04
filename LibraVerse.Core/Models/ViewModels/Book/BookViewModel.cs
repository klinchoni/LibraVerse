using LibraVerse.Core.Contracts;
using LibraVerse.Data.Models.Books;

namespace LibraVerse.Core.Models.ViewModels.Book
{
    public class BookViewModel : IBookModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int Pages { get; set; }

        public int YearPublished { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public List<BookReview> Reviews = new List<BookReview>();
    }
}