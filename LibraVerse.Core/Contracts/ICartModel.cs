using LibraVerse.Data.Models.Mappings;

namespace LibraVerse.Core.Contracts
{
    public interface ICartModel
    {
        int Id { get; set; }
        string UserId { get; set; }
        ICollection<BookCart> BooksCarts { get; set; }
        ICollection<EventCart> EventsCarts { get; set; }
    }
}
