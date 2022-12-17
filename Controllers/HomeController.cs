using LibraryCodingNight.Data;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LibraryCodingNight.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        public IActionResult Index()
        {
            var Quote = new List<Quote>();
            var query = from q in _context.Quote select q;
            foreach (var item in query) Quote.Add(item);
            Random r = new Random();
            int x = r.Next(1, Quote.Count - 1);
            var quote = Quote[x].Text;
            var author = Quote[x].Author;
            ViewBag.Quote = quote;
            ViewBag.Author = author;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}