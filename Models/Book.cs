using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryCodingNight.Models
{
    public class Book
    {   
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }

        [Column(TypeName = "smallint")]
        public int PageNumber { get; set; }

        [Column(TypeName = "varchar(13)")]
        public string ISBN { get; set; }

        public Genre? Genre { get; set; }  
        public int GenreId { get; set; }

        [Column(TypeName = "date")]
        public DateOnly PublishDate { get; set; }
        public bool IsAvailable { get; set; }

        [Column(TypeName = "text")]
        public string? Description { get; set; }

        public List<Author>? Authors { get; set; }

        public Serie? Serie { get; set; }
        public int? SerieId { get; set; }
    }
}
