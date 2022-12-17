using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace LibraryCodingNight.Models
{
    public class Serie
    {
        public int SerieId { get; set; }
        public List<Book>? Books { get; set; }
        [Display(Name = "Nazwa serii")]
        public string SerieName { get; set; }
        [Display(Name = "Opis")]
        [Column(TypeName = "text")]
        public string SerieDescription { get; set; }
    }
}
