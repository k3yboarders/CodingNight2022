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
using LibraryCodingNight.Migrations;

namespace LibraryCodingNight.Controllers
{
    public class BookAuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public BookAuthorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: BookAuthors
        public async Task<IActionResult> Index()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(await _context.BookAuthor.ToListAsync());
            }
            else
                return NotFound();

        }

        // GET: BookAuthors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor
                .FirstOrDefaultAsync(m => m.BookAuthorId == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(bookAuthor);
            }
            else
                return NotFound();


        }

        // GET: BookAuthors/Create
        public async Task <IActionResult> Create()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View();
            }
            else
                return NotFound();
        }

        // POST: BookAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookAuthorId")] BookAuthor bookAuthor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookAuthor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(bookAuthor);
            }
            else
                return NotFound();
        }

        // GET: BookAuthors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor.FindAsync(id);
            if (bookAuthor == null)
            {
                return NotFound();
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(bookAuthor);
            }
            else
                return NotFound();
        }

        // POST: BookAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookAuthorId")] BookAuthor bookAuthor)
        {
            if (id != bookAuthor.BookAuthorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookAuthor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookAuthorExists(bookAuthor.BookAuthorId))
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
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(bookAuthor);
            }
            else
                return NotFound();
        }

        // GET: BookAuthors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookAuthor == null)
            {
                return NotFound();
            }

            var bookAuthor = await _context.BookAuthor
                .FirstOrDefaultAsync(m => m.BookAuthorId == id);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(bookAuthor);
            }
            else
                return NotFound();
        }

        // POST: BookAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookAuthor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BookAuthor'  is null.");
            }
            var bookAuthor = await _context.BookAuthor.FindAsync(id);
            if (bookAuthor != null)
            {
                _context.BookAuthor.Remove(bookAuthor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookAuthorExists(int id)
        {
          return _context.BookAuthor.Any(e => e.BookAuthorId == id);
        }
    }
}
