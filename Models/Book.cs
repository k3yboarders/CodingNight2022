using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryCodingNight.Models
{
    public class Book
    {   
        public int BookId { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Wydawca")]
        public Publisher? Publisher { get; set; }
        public int PublisherId { get; set; }
        [Display(Name = "Liczba stron")]
        [Column(TypeName = "smallint")]
        public int PageNumber { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string ISBN { get; set; }
        [Display(Name = "Id gatunku")]
        public Genre? Genre { get; set; }  
        public int GenreId { get; set; }
        [Display(Name = "Data Wydania")]
        [Column(TypeName = "date")]
        public DateOnly PublishDate { get; set; }
        [Display(Name = "Czy dostępna?")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Opis")]
        [Column(TypeName = "text")]
        public string? Description { get; set; }
        [Display(Name = "Id autora")]
        public Author? Author { get; set; }
        public int AuthorId { get; set; }

        [Display(Name = "Nazwa Serii")]
        public Serie? Serie { get; set; }
        public int? SerieId { get; set; }
    }
}
