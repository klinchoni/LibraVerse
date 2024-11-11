namespace LibraVerse.Data.Models
{
    public class Book
    {
        //Set a new Guid
        public Book()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public string Author { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = null!;

    }
}
