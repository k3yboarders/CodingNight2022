namespace LibraryCodingNight.Models
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public Book? Book { get; set; }
        public Author? Author { get; set; }

    }
}
