namespace LibraryCodingNight.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardName { get; set; }
        public List<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
