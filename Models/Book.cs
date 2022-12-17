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

        public Publisher? Publisher { get; set; }
        [Display(Name = "Wydawca")]
        public int PublisherId { get; set; }
        [Display(Name = "Liczba stron")]
        [Column(TypeName = "smallint")]
        public int PageNumber { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string ISBN { get; set; }
        [Display(Name = "Nazwa gatunku")]
        public Genre? Genre { get; set; }  
        public int GenreId { get; set; }
        [Display(Name = "Data wydania")]
        [Column(TypeName = "date")]
        public DateOnly PublishDate { get; set; }
        [Display(Name = "Czy dostępna?")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Opis")]
        [Column(TypeName = "text")]
        public string? Description { get; set; }

        public Author? Author { get; set; }
        [Display(Name = "Imię i nazwisko autora")]
        public int AuthorId { get; set; }

        public Serie? Serie { get; set; }
        [Display(Name = "Nazwa serii")]
        public int? SerieId { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public List<BorrowedBook>? BorrowedBooks { get; set; }
    }
}
