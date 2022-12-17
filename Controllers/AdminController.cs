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
            if (applicationUser.RoleId == 2)
            {
                return View();
            }
            else
                return NotFound();

        }
        public async Task<IActionResult> GetBooks()
        {

            var applicationDbContext = _context.Book.Include(b => b.Genre).Include(b => b.Serie).Include(b => b.Publisher).Include(b => b.Author);
            ViewBag.Count = applicationDbContext.Count();
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 2)
            {
                return View(await applicationDbContext.ToListAsync());
            }
            else
                return NotFound();

        }
    }
}
