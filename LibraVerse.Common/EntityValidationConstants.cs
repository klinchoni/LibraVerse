
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

        public static class BookStore
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

        public static class Genre
        {
            //The minimum and maximum length of the Genre's name
            public const int GenreNameMinLength = 3;
            public const int GenreNameMaxLength = 40;
        }

        public static class BookReview
        {
            //The minimum and maximum length of the Book Review's Title
            public const int BookReviewTitleMinLength = 1;
            public const int BookReviewTitleMaxLength = 50;

            //The minimum and maximum length of the Book Review's Description
            public const int BookReviewDescriptionMinLength = 15;
            public const int BookReviewDescriptionMaxLength = 8000;

            //The minimum and maximum length of the Book Review's Rate
            public const int BookReviewRateMinRange = 1;
            public const int BookReviewRateMaxRange = 10;
        }

        public static class Event
        {
            public const string DateTimeEventFormat = "dd/MM/yyyy HH:mm";

            //Topic
            public const int EventTopicMinLength = 10;
            public const int EventTopicMaxLength = 100;

            //Description
            public const int EventDescriptionMinLength = 50;
            public const int EventDescriptionMaxLength = 5000;

            //Location
            public const int EventLocationMinLength = 10;
            public const int EventLocationMaxLength = 100;

            //ImageUrl
            public const int EventImageUrlMinLength = 5;
            public const int EventImageUrlMaxLength = 500;

            //Seats
            public const int EventSeatsMinRange = 1;
            public const uint EventSeatsMaxRange = uint.MaxValue;

            //Ticket Price
            public const int EventTicketPriceMinRange = 0;
            public const uint EventTicketPriceMaxRange = uint.MaxValue;
        }

        public static class Article
        {
            public const string DateTimeArticleFormat = "dd/MM/yyyy HH:mm";

            //Title
            public const int ArticleTitleMinLength = 5;
            public const int ArticleTitleMaxLength = 100;

            //Content
            public const int ArticleContentMinLength = 100;
            public const int ArticleContentMaxLength = 10000;

            //ImageUrl
            public const int ArticleImageUrlMinLength = 5;
            public const int ArticleImageUrlMaxLength = 500;

            //ViewsCount
            public const int ArticleViewsCountMinRange = 0;
            public const int ArticleViewsCountMaxLength = int.MaxValue;
        }
        public static class ArticleComment
        {
            //Title
            public const int ArticleCommentTitleMinLength = 1;
            public const int ArticleCommentTitleMaxLength = 50;

            //Description
            public const int ArticleCommentDescriptionMinLength = 15;
            public const int ArticleCommentDescriptionMaxLength = 2000;
        }

        public static class ApplicationUser
        {
            public const int ApplicationUserFirstNameMinLength = 1;
            public const int ApplicationUserFirstNameMaxLength = 30;

            public const int ApplicationUserLastNameMinLength = 1;
            public const int ApplicationUserLastNameMaxLength = 30;
        }
    }
}

