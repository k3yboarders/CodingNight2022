using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace LibraryCodingNight.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        [Display(Name = "Nazwa Wydawcy")]
        public string PublisherName { get; set; }

        [Display(Name = "Numer telefonu")]
        [Column(TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }
    }
}
