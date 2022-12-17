using System.ComponentModel.DataAnnotations;
namespace LibraryCodingNight.Models
{
    public class BorrowedBook
    {
        
        public int BorrowedBookId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        [Display(Name = "Książka")]
        public int BookId { get; set; }
        public Book? Book { get; set; }
        [Display(Name = "Pożyczone (od)")]
        public DateTime BorrowedFrom { get; set; }
        [Display(Name = "Pożyczone (do)")]
        public DateTime BorrowedTo { get; set; }

    }
}
