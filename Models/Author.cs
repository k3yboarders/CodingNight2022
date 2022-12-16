using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryCodingNight.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string AuthorFirstName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string AuthorLastName { get; set; }
        public BookAuthor? BookAuthor { get; set; }

    }
}
