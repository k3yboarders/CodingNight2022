using LibraryCodingNight.Data;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LibraryCodingNight.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
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
        public async Task<IActionResult> AllBooks()
        {

            var applicationDbContext = _context.Book.Include(b => b.Genre).Include(b => b.Serie).Include(b => b.Publisher).Include(b => b.Author).Where(b => b.IsAvailable == true);
            ViewBag.Count = applicationDbContext.Count();
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 2)
            {
                return View(await applicationDbContext.ToListAsync());
            }
            else
                return NotFound();

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Genre)
                .Include(b => b.Serie)
                .Include(b => b.Publisher)
                 .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> AllBooks(string searchString, int category)
        {
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
        public async Task<IActionResult> SuggestBook()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 2)
            {
                return View();
            }
            else
                return NotFound();


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuggestBook([Bind("SuggestedBookId,SuggestedBookTitle,SuggesteBookAuthor")] SuggestedBook suggestedBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suggestedBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suggestedBook);
        }
        public async Task<IActionResult> Reservation()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 2)
            {
                var applicationDbContext = _context.Reservation.Include(r => r.Book).Where(b => b.ApplicationUserId == applicationUser.Id).Where(b => b.IsActual == true);
                return View(await applicationDbContext.ToListAsync());
            }
            else
                return NotFound();

        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> ReservationDetails(int? id)
        {
            if (id == null || _context.Reservation == null)
            {
                return NotFound();
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            var reservation = await _context.Reservation
                .Include(r => r.Book)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }
            if (applicationUser.RoleId == 2)
                return View(reservation);
            else
                return NotFound();
        }
        public async Task<IActionResult> ReserveBook(int id)
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            Reservation reservation = new Reservation();
            reservation.BookId = id;
            reservation.DateOfReserve = DateTime.Now;
            reservation.ApplicationUserId = applicationUser.Id;
            reservation.IsActual = true;
            if (_context.Book.SingleOrDefault(b => b.BookId == id).IsAvailable == true)
            {
                var result = _context.Book.SingleOrDefault(b => b.BookId == id);
                result.IsAvailable = false;
                await _context.SaveChangesAsync();
                if (ModelState.IsValid)
                {
                    _context.Add(reservation);
                    ViewBag.Success = "WEEE";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AllBooks));
                }
                //zwroc zielone ze jest dostepna
            }
            else
            {
                //zwroc czerwone ze nie jest dostepna
            }

            return View();
        }
        public async Task<IActionResult> BorrowedBooks()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 2)
            {
                var applicationDbContext = _context.BorrowedBook.Include(b => b.Book).Where(b => b.ApplicationUserId == applicationUser.Id);
                return View(await applicationDbContext.ToListAsync());
            }
            else
                return NotFound();
        }
    }
    
}
