using Microsoft.AspNetCore.Identity;

namespace LibraryCodingNight.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
