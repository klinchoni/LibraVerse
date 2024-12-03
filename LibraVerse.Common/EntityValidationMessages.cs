namespace LibraVerse.Common
{
    public static class EntityValidationMessages
    {
        public static class Data
        {
            public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";
            public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";
        }

        public static class Book
        {
            public const string TitleRequiredMessage = "Book title is required!";
            public const string GenreRequiredMessage = "Genre is required!";
            public const string ReleaseDateRequiredMessage = "Release date is required in format yyyy";
            public const string PagesRequiredMessage = "Add the number of the pages.";
            public const string AuthorRequiredMessage = "Author name is required!";
            public const string DescriptionRequiredMessage = "Please, add more text!";
        }

        public static class User
        {
            public const string ErrorMessage = "ErrorMessage";
        }
    }
}
