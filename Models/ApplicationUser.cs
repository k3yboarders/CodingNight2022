using Microsoft.AspNetCore.Identity;

namespace LibraryCodingNight.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData] public string FirstName { get; set; } = "";

        [PersonalData] public string LastName { get; set; } = "";

        [PersonalData] public DateTime? BirthDate { get; set; }

        [PersonalData] public int ThemeId { get; set; }

    }
}
