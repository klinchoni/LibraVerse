namespace LibraVerse.Core.Extensions
{
    using LibraVerse.Core.Contracts;

    public static class BookStoreExtensions
    {
        public static string GetInformation(this IBookStoreModel bookStore)
        {
            return bookStore.Name.Replace(" ", "");
        }
    }
}