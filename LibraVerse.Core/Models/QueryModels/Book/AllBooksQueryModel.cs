﻿namespace LibraVerse.Core.Models.QueryModels.Book
{
    using LibraVerse.Core.Enums;
    using System.ComponentModel.DataAnnotations;

    public class AllBooksQueryModel
    {
        public int BooksPerPage { get; } = 8;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Сортиране")]
        public BookSorting Sorting { get; set; }

        public int TotalBooksCount { get; set; }
        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Жанр")]
        public string Genre { get; set; } = null!;
        public IEnumerable<string> Genres { get; set; } = null!;

        public int BookStoreId { get; set; } = -1;

        public IEnumerable<BookServiceModel> Books { get; set; } = new HashSet<BookServiceModel>();
    }
}