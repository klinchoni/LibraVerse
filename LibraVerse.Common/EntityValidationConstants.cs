
namespace LibraVerse.Common
{
    public static class EntityValidationConstants
    {
        public static class Book
        {
            //The maximum length of the book title
            public const int TitleMaxLength = 50; 

            //The minimum and maximum length of the Author name
            public const int NameMinLength = 10; 
            public const int NameMaxLength = 60;

            //The minimum and maximum length of the Genre
            public const int GenreMinLength = 5; 
            public const int GenreMaxLength = 30;

            //The minimum and maximum quantity (numbers) of the Book's pages.
            public const double BookPageMinValue = 1;
            public const double BookPageMaxValue = 10000;

            //The date format
            public const string ReleaseDateFormat = "MM/yyyy";

            //The minimum and maximum length of the Description
            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 1000;

            //The minimum and maximum length of the Image's url
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;

            
           //public const string PriceMin = 4.00;
           //public const string PriceMax = 300.00;
        }

        public static class BookStores
        {
            public const string DateTimeBookStoreFormat = "HH:mm";

            //The minimum and maximum length of the Book Store's Name
            public const int BookStoreNameMinLength = 1;
            public const int BookStoreNameMaxLength = 100;

            //The minimum and maximum length of the Book Store's Location
            public const int BookStoreLocationMinLength = 10;
            public const int BookStoreLocationMaxLength = 100;

            //The minimum and maximum length of the Book Store's Contact Info
            public const int BookStoreContactMinLength = 8;
            public const int BookStoreContactMaxLength = 10;

            //The minimum and maximum length of the Book Store's ImageUrl
            public const int BookStoreImageUrlMinLength = 5;
            public const int BookStoreImageUrlMaxLength = 500;
        }
    }
}

