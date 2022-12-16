using LibraryCodingNight.Data;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LibraryCodingNight.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View();
            }
            else
                return NotFound();

        }
    }
}
