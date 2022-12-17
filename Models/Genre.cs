using System.ComponentModel.DataAnnotations;
namespace LibraryCodingNight.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Display(Name = "Nazwa Gatunku")]
        public string GenreName { get; set; }
        public List<Book>? Books { get; set; }
    }
}
