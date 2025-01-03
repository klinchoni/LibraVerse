﻿namespace LibraVerse.Core.Services
{
    using System;
    using Microsoft.EntityFrameworkCore;

    using LibraVerse.Core.Contracts;
    using LibraVerse.Core.Enums;
    using LibraVerse.Core.Models.QueryModels.Book;
    using LibraVerse.Core.Models.QueryModels.BookStore;
    using LibraVerse.Core.Models.ViewModels.BookStore;

    using LibraVerse.Data.Repository;
    using LibraVerse.Data.Models.Books;
    using LibraVerse.Data.Models.BookStores;

    using static LibraVerse.Common.Constants.EntityValidationConstants.BookStore;

    public class BookStoreService : IBookStoreService
    {
        private readonly IRepository repository;

        public BookStoreService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<BookStoreIndexViewModel>> LastTenBookStoresAsync()
        {
            return await repository
                .AllAsReadOnly<BookStore>()
                .OrderByDescending(b => b.BooksBookStores.Count)
                .Select(bs => new BookStoreIndexViewModel()
                {
                    Id = bs.Id,
                    Name = bs.Name,
                    ImageUrl = bs.ImageUrl
                })
                .Take(10)
                .ToListAsync();
        }

        public async Task<BookStoreQueryServiceModel> AllAsync(
            string? searchTerm = null,
            BookStoreStatus status = BookStoreStatus.All,
            int currentPage = 1,
            int bookStoresPerPage = 4)
        {
            var bookStoresToShow = repository.AllAsReadOnly<BookStore>();

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                bookStoresToShow = bookStoresToShow
                .Where(bs => normalizedSearchTerm.Contains(bs.Name.ToLower())
                || normalizedSearchTerm.Contains(bs.Location.ToLower())
                || normalizedSearchTerm.Contains(bs.OpeningTime.ToString().ToLower())
                || normalizedSearchTerm.Contains(bs.ClosingTime.ToString().ToLower())

                || bs.Name.ToLower().Contains(normalizedSearchTerm)
                || bs.Location.ToLower().Contains(normalizedSearchTerm)
                || bs.OpeningTime.ToString().ToLower().Contains(normalizedSearchTerm)
                || bs.ClosingTime.ToString().ToLower().Contains(normalizedSearchTerm));
            }

            var currentBookStores = await bookStoresToShow.OrderByDescending(bs => bs.Id).ToListAsync();
            if (status == BookStoreStatus.Open)
            {
                currentBookStores = currentBookStores.Where(bs => IsBookstoreOpen(bs.OpeningTime, bs.ClosingTime).Result == true).ToList();
            }
            else if (status == BookStoreStatus.Closed)
            {
                currentBookStores = currentBookStores.Where(bs => IsBookstoreOpen(bs.OpeningTime, bs.ClosingTime).Result == false).ToList();
            }

            var bookStores = currentBookStores
                .Skip((currentPage - 1) * bookStoresPerPage)
                .Take(bookStoresPerPage)
                .ToList();

            int totalBookStores = currentBookStores.Count();

            var bookStoreServiceModels = bookStores.Select(bs => new BookStoreServiceModel()
            {
                Id = bs.Id,
                Name = bs.Name,
                Location = bs.Location,
                OpeningTime = bs.OpeningTime,
                ClosingTime = bs.ClosingTime,
                ImageUrl = bs.ImageUrl,
                Status = IsBookstoreOpen(bs.OpeningTime, bs.ClosingTime).Result
            }).ToList();

            return new BookStoreQueryServiceModel()
            {
                BookStores = bookStoreServiceModels,
                TotalBookStoresCount = totalBookStores
            };
        }

        public static async Task<bool> IsBookstoreOpen(DateTime openingTime, DateTime closingTime)
        {
            var now = DateTime.Now;

            if (now.Hour < openingTime.Hour || now.Hour > closingTime.Hour)
            {
                return false;
            }

            if (now.Hour > openingTime.Hour && now.Hour < closingTime.Hour)
            {
                return true;
            }

            if (now.Hour == openingTime.Hour)
            {
                if (now.Minute >= openingTime.Minute)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (now.Minute <= closingTime.Minute)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> BookStoreExistsAsync(int bookStoreId)
        {
            return await repository.AllAsReadOnly<BookStore>()
                .AnyAsync(bs => bs.Id == bookStoreId);
        }

        public async Task<BookStore> FindBookStoreByIdAsync(int bookStoreId)
        {
            return await repository.GetByIdAsync<BookStore>(bookStoreId);
        }

        public async Task<BookStoreDetailsViewModel> DetailsAsync(int bookStoreId)
        {
            BookStore? currentBookStore = await repository.GetByIdAsync<BookStore>(bookStoreId);

            var currentBookStoreDetails = new BookStoreDetailsViewModel()
            {
                Id = currentBookStore.Id,
                Name = currentBookStore.Name,
                Location = currentBookStore.Location,
                OpeningTime = currentBookStore.OpeningTime.ToString(DateTimeBookStoreFormat),
                ClosingTime = currentBookStore.ClosingTime.ToString(DateTimeBookStoreFormat),
                Contact = currentBookStore.Contact,
                Status = await IsBookstoreOpen(currentBookStore.OpeningTime, currentBookStore.ClosingTime) ? "Отворено" : "Затворено",
                ImageUrl = currentBookStore.ImageUrl
            };

            return currentBookStoreDetails;
        }

        public async Task<BookQueryServiceModel> AllBooksAsync(
            int bookStoreId,
            string? genre = null,
            string? searchTerm = null,
            BookSorting sorting = BookSorting.Newest,
            int currentPage = 1,
            int booksPerPage = 4)
        {
            var booksToShow = repository.AllAsReadOnly<Book>()
                .Where(b => b.BooksBookStores.Any(bbs => bbs.BookStoreId == bookStoreId));

            if (genre != null)
            {
                booksToShow = booksToShow
                    .Where(b => b.Genre.Name.ToLower() == genre.ToLower());
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();

                booksToShow = booksToShow
                .Where(b => normalizedSearchTerm.Contains(b.Title.ToLower())
                || normalizedSearchTerm.Contains(b.Author.ToLower())
                || normalizedSearchTerm.Contains(b.Genre.Name.ToLower())

                || b.Title.ToLower().Contains(normalizedSearchTerm)
                || b.Author.ToLower().Contains(normalizedSearchTerm)
                || b.Genre.Name.ToLower().Contains(normalizedSearchTerm));
            }

            booksToShow = sorting switch
            {
                BookSorting.Oldest => booksToShow.OrderBy(b => b.Id),
                BookSorting.PriceAscending => booksToShow.OrderBy(b => b.Price).ThenByDescending(b => b.Id),
                BookSorting.PriceDescending => booksToShow.OrderByDescending(b => b.Price).ThenByDescending(b => b.Id),
                BookSorting.TitleAscending => booksToShow.OrderBy(b => b.Title).ThenByDescending(b => b.Id),
                BookSorting.TitleDescending => booksToShow.OrderByDescending(b => b.Title).ThenByDescending(b => b.Id),
                BookSorting.AuthorAscending => booksToShow.OrderBy(b => b.Author).ThenByDescending(b => b.Id),
                BookSorting.AuthorDescending => booksToShow.OrderByDescending(b => b.Author).ThenByDescending(b => b.Id),
                _ => booksToShow.OrderByDescending(b => b.Id),
            };

            var books = await booksToShow
                .Skip((currentPage - 1) * booksPerPage)
                .Take(booksPerPage)
                .ProjectToBookServiceModel()
                .ToListAsync();

            int totalBooks = await booksToShow.CountAsync();

            return new BookQueryServiceModel()
            {
                Books = books,
                TotalBooksCount = totalBooks
            };
        }
    }
}