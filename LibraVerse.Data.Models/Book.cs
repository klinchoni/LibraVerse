using LibraVerse.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static LibraVerse.Common.EntityValidationConstants.Book;

namespace LibraVerse.Data.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Title of the book")]
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; } = null!;

    }
}
