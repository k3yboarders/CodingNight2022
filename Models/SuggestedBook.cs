using System.ComponentModel.DataAnnotations;
namespace LibraryCodingNight.Models
{
    public class SuggestedBook
    {
        public int SuggestedBookId { get; set; }
        [Display(Name = "Tytuł Książki")]
        public string SuggestedBookTitle { get; set; }
        [Display(Name = "Autor")]
        public string SuggesteBookAuthor { get; set; }
    }
}
