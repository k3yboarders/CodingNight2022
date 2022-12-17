using LibraryCodingNight.Data;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> GetBooks()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreName");
            ViewData["SerieId"] = new SelectList(_context.Serie, "SerieId", "SerieName");
            ViewData["PublisherId"] = new SelectList(_context.Serie, "PublisherId", "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorName");
            var applicationDbContext = _context.Book.Include(b => b.Genre).Include(b => b.Serie).Include(b => b.Publisher).Include(b => b.Author);
            ViewBag.Count = applicationDbContext.Count();
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(await applicationDbContext.ToListAsync());
            }
            else
                return NotFound();

        }
        [HttpPost]
        public async Task<IActionResult> AllBooks(string searchString, int category)
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreName");
            ViewData["SerieId"] = new SelectList(_context.Serie, "SerieId", "SerieName");
            ViewData["PublisherId"] = new SelectList(_context.Serie, "PublisherId", "PublisherName");
            ViewData["AuthorId"] = new SelectList(_context.Author, "AuthorId", "AuthorName");
            var books = from b in _context.Book select b;
            ViewBag.searchString = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                switch (category)
                {
                    case 2:
                        books = books.Where(b => b.Author.AuthorName!.Contains(searchString));
                        ViewBag.SelectedItem = 2;
                        ViewBag.Count = books.Count();
                        break;
                    case 3:
                        books = books.Where(b => b.ISBN!.Contains(searchString));
                        ViewBag.SelectedItem = 3;
                        ViewBag.Count = books.Count();
                        break;
                    case 4:
                        books = books.Where(b => b.Genre.GenreName!.Contains(searchString));

                        ViewBag.SelectedItem = 4;
                        ViewBag.Count = books.Count();
                        break;
                    case 5:
                        books = books.Where(b => b.Serie.SerieName!.Contains(searchString));
                        ViewBag.SelectedItem = 5;
                        ViewBag.Count = books.Count();
                        break;
                    default:
                        books = books.Where(b => b.Title!.Contains(searchString));
                        ViewBag.SelectedItem = 1;
                        ViewBag.Count = books.Count();
                        break;
                }

            }

            return View(await books.ToListAsync());
        }
        public async Task<IActionResult> GetSuggestedBooks()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookName");
            var applicationDbContext = _context.SuggestedBook;
            ViewBag.Count = applicationDbContext.Count();
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(await applicationDbContext.ToListAsync());
            }
            else
                return NotFound();

        }
        public async Task<IActionResult> GetReservations()
        {
            ViewData["BookId"] = new SelectList(_context.Book, "BookId", "BookName");
            var applicationDbContext = _context.Reservation;
            ViewBag.Count = applicationDbContext.Count();
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(await applicationDbContext.ToListAsync());
            }
            else
                return NotFound();

        }
        public async Task<IActionResult> DeleteReservation(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Book)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservation'  is null.");
            }
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
