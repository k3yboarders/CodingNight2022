using Microsoft.AspNetCore.Identity;

namespace LibraryCodingNight.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData] public string FirstName { get; set; } = "";

        [PersonalData] public string LastName { get; set; } = "";

        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [PersonalData] public DateTime? BirthDate { get; set; }

        [PersonalData] public int ThemeId { get; set; }
        [PersonalData] public string Card { get; set; }
        public int RoleId { get; set; } = 2;
        public ApplicationRole? ApplicationRole { get; set; }
        public List<Reservation>? Reservations { get; set; }
        public List<BorrowedBook>? BorrowedBooks { get; set; }
    }
}
