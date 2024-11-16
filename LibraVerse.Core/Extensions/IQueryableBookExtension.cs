namespace System.Linq
{
    using LibraVerse.Core.Models.QueryModels.Book;
    using LibraVerse.Data.Models.Books;

    public static class IQueryableBookExtension
    {
        public static IQueryable<BookServiceModel> ProjectToBookServiceModel(this IQueryable<Book> books)
        {
            return books.Select(b => new BookServiceModel()
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price,
                ImageUrl = b.ImageUrl
            });
        }
    }
}