using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace LibraryCodingNight.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? PhoneNumber { get; set; }
    }
}
