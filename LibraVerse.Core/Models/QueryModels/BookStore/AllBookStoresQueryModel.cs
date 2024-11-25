﻿using LibraVerse.Core.Contracts;
using LibraVerse.Core.Enums;
using LibraVerse.Core.Models.QueryModels.Article;
using System.ComponentModel.DataAnnotations;

namespace LibraVerse.Core.Models.QueryModels.BookStore
{
    public class AllBookStoresQueryModel
    {
        public int BookStoresPerPage { get; } = 8;
        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Търсене")]
        public string SearchTerm { get; set; } = null!;

        [Display(Name = "Статус")]
        public BookStoreStatus Status { get; set; }

        public int TotalBookStoresCount { get; set; }

        public IEnumerable<BookStoreServiceModel> BookStores { get; set; } = new HashSet<BookStoreServiceModel>();
    }
}