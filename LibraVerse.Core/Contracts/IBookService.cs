﻿namespace LibraVerse.Core.Contracts
{
    using LibraVerse.Core.Enums;

    using LibraVerse.Core.Models.QueryModels.Book;
    using LibraVerse.Core.Models.QueryModels.BookStore;
    using LibraVerse.Core.Models.ViewModels.Book;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.BookUserActions;

    public interface IBookService
    {
        Task<BookQueryServiceModel> AllAsync(
            string? genre = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 8);

        Task<BookStoreQueryServiceModel> AllBookstoresWithBook(
            int bookId,
            string? searchTerm = null,
            BookStoreStatus status = BookStoreStatus.All,
            int currentPage = 1,
            int bookStoresPerPage = 4);

        Task<IEnumerable<GenreViewModel>> AllGenresAsync();
        Task<IEnumerable<string>> AllGenresNamesAsync();
        Task<Book> FindBookByIdAsync(int bookId);
        Task<bool> BookExistsAsync(int bookId);
        Task<bool> GenreExistsAsync(int genreId);
        Task<BookViewModel> DetailsAsync(int bookId);
        Task<BookQueryServiceModel> AllWantToReadBooksIdsByUserIdAsync(
            string userId,
            string? genre = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4);
        Task<BookQueryServiceModel> AllCurrentlyReadingBooksIdsByUserIdAsync(
            string userId,
            string? genre = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 8);
        Task<BookQueryServiceModel> AllReadBooksIdsByUserIdAsync(string userId,
            string? genre = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 8);
        Task<bool> BookIsInAnotherCollectionAsync(int bookId, string userId);
        Task<int> RemoveBookFromAllCollectionsAsync(int bookId, string userId);
        Task<bool> BookIsCurrentlyReadingAsync(int bookId, string userId);
        Task<bool> BookIsWantToReadAsync(int bookId, string userId);
        Task<bool> BookIsReadAsync(int bookId, string userId);
        Task<int> AddWantToReadBookAsync(int bookId, string userId);
        Task<int> AddCurrentlyReadingBookAsync(int bookId, string userId);
        Task<int> AddReadBookAsync(int bookId, string userId);
        Task<int> RemoveWantToReadBookAsync(int bookId, string userId);
        Task<int> RemoveCurrentlyReadingBookAsync(int bookId, string userId);
        Task<int> RemoveReadBookAsync(int bookId, string userId);
        Task<int> AddBookReviewAsync(BookReviewAddViewModel reviewForm, string userId, int bookId);
        Task<BookReviewQueryServiceModel> AllBookReviewsAsync(
            int bookId,
            string bookTitle,
            string? searchTerm = null,
            BookReviewSorting sorting = BookReviewSorting.Newest,
            int currentPage = 1,
            int reviewsPerPage = 8);
        Task<BookReview> FindBookReviewAsync(string userId, int bookId);
        Task<BookReview> FindBookReviewByIdAsync(int reviewId);
        Task<BookReviewDeleteViewModel> DeleteBookReviewAsync(int reviewId);
        Task<int> DeleteBookReviewConfirmedAsync(int reviewId);
        Task<BookReviewDetailsViewModel> BookReviewDetailsAsync(int reviewId);
        Task<BookReviewEditViewModel> EditBookReviewGetAsync(int reviewId);
        Task<int> EditBookReviewPostAsync(BookReviewEditViewModel bookReviewForm);
        Task<BookReviewQuestionViewModel> BookReviewQuestionAsync(int bookId);
        Task<ChangePageViewModel> ChangePageGetAsync(int bookId, string userId);
        Task<int> ChangePagePostAsync(ChangePageViewModel pageForm);
        Task<BookUserCurrentlyReading> FindBookCurrentlyReadingAsync(int bookId, string userId);
    }
}