using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryCodingNight.Data;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LibraryCodingNight.Controllers
{

    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Book.Include(b => b.Genre).Include(b => b.Serie);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Books/Details/5
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
        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId");
            ViewData["SerieId"] = new SelectList(_context.Serie, "SerieId", "SerieId");
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View();
            }
            else
                return NotFound();


        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,PublisherId,PageNumber,ISBN,GenreId,PublishDate,IsAvailable,Description,SerieId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", book.GenreId);
            ViewData["SerieId"] = new SelectList(_context.Serie, "SerieId", "SerieId", book.SerieId);
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(book);
            }
            else
                return NotFound();


        }
        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", book.GenreId);
            ViewData["SerieId"] = new SelectList(_context.Serie, "SerieId", "SerieId", book.SerieId);
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(book);
            }
            else
                return NotFound();
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,PublisherId,PageNumber,ISBN,GenreId,PublishDate,IsAvailable,Description,SerieId")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "GenreId", book.GenreId);
            ViewData["SerieId"] = new SelectList(_context.Serie, "SerieId", "SerieId", book.SerieId);
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(book);
            }
            else
                return NotFound();
        }
        [Authorize(Policy = "RequireAdminRole")]
        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(book);
            }
            else
                return NotFound();
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return _context.Book.Any(e => e.BookId == id);
        }
    }
}
