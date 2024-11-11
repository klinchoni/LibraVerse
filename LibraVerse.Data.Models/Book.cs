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
        public string Title { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

    }
}
