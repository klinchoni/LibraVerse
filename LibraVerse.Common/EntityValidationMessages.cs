using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraVerse.Common
{
    public static class EntityValidationMessages
    {
        public static class Book
        {
            public const string TitleRequiredMessage = "Book title is required!";
            public const string GenreRequiredMessage = "Genre is required!";
            public const string ReleaseDateRequiredMessage = "Release date is required in format MM/yyyy";
            public const string AuthorRequiredMessage = "Author name is required!";
            public const string PagesRequiredMessage = "Add the number of the pages.";
        }
    }
}
