﻿using LibraVerse.Core.Contracts;

namespace LibraVerse.Core.Models.ViewModels.BookStore
{
    public class BookStoreIndexViewModel : IBookStoreModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}