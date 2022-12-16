using LibraryCodingNight.Data;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllBooks()
        {
            //ViewData["Categories"] = new List<string> {"Tytuł", "Autor", "ISBN", "Gatunek", "Seria"};
            var applicationDbContext = _context.Book.Include(b => b.Genre).Include(b => b.Serie);
            return View(await applicationDbContext.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [HttpPost]
        public async Task<IActionResult> AllBooks(string searchString, string category)
        {
            var books = from b in _context.Book select b;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(b => b.Title!.Contains(searchString));
            }

            return View(await books.ToListAsync());
        }
    }
    
}
