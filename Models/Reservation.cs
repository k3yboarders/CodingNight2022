using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryCodingNight.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        [Display(Name = "Książka")]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [Display(Name = "Data rezerwacji")]
        public DateTime DateOfReserve { get; set; }
        public bool IsActual { get; set; }
    }
}