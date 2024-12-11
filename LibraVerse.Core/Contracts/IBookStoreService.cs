namespace LibraVerse.Core.Contracts
{
    using LibraVerse.Core.Enums;

    using LibraVerse.Core.Models.QueryModels.Book;
    using LibraVerse.Core.Models.QueryModels.BookStore;
    using LibraVerse.Core.Models.ViewModels.BookStore;
    using LibraVerse.Data.Models.BookStores;

    public interface IBookStoreService
    {
        Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync();
        Task<BookStoreQueryServiceModel> AllAsync(
            string? searchTerm = null,
            BookStoreStatus status = BookStoreStatus.All,
            int currentPage = 1,
            int bookStoresPerPage = 4);
        Task<bool> BookStoreExistsAsync(int bookStoreId);
        Task<BookStore> FindBookStoreByIdAsync(int bookStoreId);
        Task<BookStoreDetailsViewModel> DetailsAsync(int bookStoreId);
        Task<BookQueryServiceModel> AllBooksAsync(
            int bookStoreId,
            string? genre = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);
    }
}