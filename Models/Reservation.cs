namespace LibraryCodingNight.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }
        public DateTime DateOfReserve { get; set; }
    }
}