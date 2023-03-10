using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryCodingNight.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name = "Imie i nazwisko")]
        [Column(TypeName = "text")]
        public string AuthorName { get; set; }   

        public List<Book>? Books { get; set; }

    }
}
