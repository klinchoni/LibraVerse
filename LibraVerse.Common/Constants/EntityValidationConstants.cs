namespace LibraVerse.Common.Constants
{
    public static class EntityValidationConstants
    {

        public static class ApplicationUserConstant
        {
            public const int ApplicationUserFirstNameMinLength = 1;
            public const int ApplicationUserFirstNameMaxLength = 50;

            public const int ApplicationUserLastNameMinLength = 1;
            public const int ApplicationUserLastNameMaxLength = 50;
        }

        public static class Publisher
        {
            public const string PublisherEmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        }

        public static class Genre
        {
            //The minimum and maximum length of the Genre's name
            public const int GenreNameMinLength = 3;
            public const int GenreNameMaxLength = 50;
        }

        public static class BookConstants
        {
            //The maximum length of the book title
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 100;

            //The minimum and maximum length of the Author name
            public const int NameMinLength = 10;
            public const int NameMaxLength = 60;

            //The minimum and maximum length of the Genre
            public const int GenreMinLength = 5;
            public const int GenreMaxLength = 30;

            //The minimum and maximum quantity (numbers) of the Book's pages.
            public const double BookPageMinValue = 1;
            public const double BookPageMaxValue = 10000;

            //The minimum and maximum range of the Book's publishing year
            public const int YearPublishedMinRange = 100;
            public const int YearPublishedMaxRange = 2024;

            //The minimum and maximum length of the Description
            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 10000;

            //The minimum and maximum length of the Image's url
            public const int ImageUrlMinLength = 8;
            public const int ImageUrlMaxLength = 2083;


            //The minimum and maximum value of the Book's price
            public const string PriceMinValue = "1";
            public const string PriceMaxValue = "2000";
        }

        public static class BookReview
        {
            //The minimum and maximum length of the Book Review's Title
            public const int BookReviewTitleMinLength = 1;
            public const int BookReviewTitleMaxLength = 50;

            //The minimum and maximum length of the Book Review's Description
            public const int BookReviewDescriptionMinLength = 1;
            public const int BookReviewDescriptionMaxLength = 10000;

            //The minimum and maximum length of the Book Review's Rate
            public const int BookReviewRateMinRange = 1;
            public const int BookReviewRateMaxRange = 10;
        }

        public static class BookCurrentlyReadingConstants
        {
            public const int BookCurrentPageMinRange = 1;
        }

        public static class BookStore
        {
            public const string DateTimeBookStoreFormat = "HH:mm";

            //The minimum and maximum length of the Book Store's Name
            public const int BookStoreNameMinLength = 1;
            public const int BookStoreNameMaxLength = 70;

            //The minimum and maximum length of the Book Store's Location
            public const int BookStoreLocationMinLength = 10;
            public const int BookStoreLocationMaxLength = 70;

            //The minimum and maximum length of the Book Store's Phone Number
            public const int BookStoreContactMinLength = 8;
            public const int BookStoreContactMaxLength = 15;

            //The minimum and maximum length of the Book Store's ImageUrl
            public const int BookStoreImageUrlMinLength = 5;
            public const int BookStoreImageUrlMaxLength = 500;
        }

        public static class Article
        {
            public const string DateTimeArticleFormat = "dd/MM/yyyy HH:mm";

            //Title of the Article
            public const int ArticleTitleMinLength = 3;
            public const int ArticleTitleMaxLength = 100;

            //What it is about (content)
            public const int ArticleContentMinLength = 5;
            public const int ArticleContentMaxLength = 10000;

            //The ImageUrl of the current Article
            public const int ArticleImageUrlMinLength = 5;
            public const int ArticleImageUrlMaxLength = 500;

            //The ViewsCount of the current Article
            public const int ArticleViewsCountMinRange = 0;
            public const int ArticleViewsCountMaxLength = int.MaxValue;
        }

        public static class ArticleComment
        {
            //Title of the comment
            public const int ArticleCommentTitleMinLength = 1;
            public const int ArticleCommentTitleMaxLength = 1000;

            //The comment
            public const int ArticleCommentDescriptionMinLength = 5;
            public const int ArticleCommentDescriptionMaxLength = 10000;
        }

        public static class Event
        {
            public const string DateTimeEventFormat = "dd/MM/yyyy HH:mm";

            //The Topic
            public const int EventTopicMinLength = 5;
            public const int EventTopicMaxLength = 1000;

            // The Description of the Event
            public const int EventDescriptionMinLength = 5;
            public const int EventDescriptionMaxLength = 10000;

            //The Location of the Event
            public const int EventLocationMinLength = 5;
            public const int EventLocationMaxLength = 1000;

            //The ImageUrl of the Event
            public const int EventImageUrlMinLength = 5;
            public const int EventImageUrlMaxLength = 500;

            //The Seats for each person
            public const int EventSeatsMinRange = 1;
            public const uint EventSeatsMaxRange = uint.MaxValue;

            //The Price of the Ticket
            public const int EventTicketPriceMinRange = 0;
            public const uint EventTicketPriceMaxRange = uint.MaxValue;
        }
    }
}

