namespace LibraryCodingNight.Models
{
    public class BorrowedBook
    {
        public int BorrowedBookId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public DateTime BorrowedFrom { get; set; }
        public DateTime BorrowedTo { get; set; }

    }
}
