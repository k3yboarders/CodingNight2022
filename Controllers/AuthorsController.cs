using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryCodingNight.Data;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryCodingNight.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public AuthorsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }
        // GET: Authors
        public async Task<IActionResult> Index()
            {
                var applicationUser = await UserManager.GetUserAsync(User);
                if (applicationUser.RoleId == 1)
                {
                    return View(await _context.Author.ToListAsync());
                }
                else
                    return NotFound();
            }

            // GET: Authors/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null || _context.Author == null)
                {
                    return NotFound();
                }

                var author = await _context.Author
                    .FirstOrDefaultAsync(m => m.AuthorId == id);
                if (author == null)
                {
                    return NotFound();
                }
                var applicationUser = await UserManager.GetUserAsync(User);
                if (applicationUser.RoleId == 1)
                {
                    return View(author);
                }
                else
                    return NotFound();
            }

            // GET: Authors/Create
            public async Task<IActionResult> Create()
            {
                var applicationUser = await UserManager.GetUserAsync(User);
                if (applicationUser.RoleId == 1)
                {
                    return View();
                }
                else
                    return NotFound();

            }

            // POST: Authors/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("AuthorId,AuthorName")] Author author)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(author);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                var applicationUser = await UserManager.GetUserAsync(User);
                if (applicationUser.RoleId == 1)
                {
                    return View(author);
                }
                else
                    return NotFound();
            }

            // GET: Authors/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.Author == null)
                {
                    return NotFound();
                }

                var author = await _context.Author.FindAsync(id);
                if (author == null)
                {
                    return NotFound();
                }
                var applicationUser = await UserManager.GetUserAsync(User);
                if (applicationUser.RoleId == 1)
                {
                    return View(author);
                }
                else
                    return NotFound();
            }

            // POST: Authors/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("AuthorId,AuthorName")] Author author)
            {
                if (id != author.AuthorId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(author);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AuthorExists(author.AuthorId))
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
                    return View(author);
                }
                else
                    return NotFound();
            }

            // GET: Authors/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.Author == null)
                {
                    return NotFound();
                }

                var author = await _context.Author
                    .FirstOrDefaultAsync(m => m.AuthorId == id);
                if (author == null)
                {
                    return NotFound();
                }

                var applicationUser = await UserManager.GetUserAsync(User);
                if (applicationUser.RoleId == 1)
                {
                    return View(author);
                }
                else
                    return NotFound();
            }

            // POST: Authors/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.Author == null)
                {
                    return Problem("Entity set 'ApplicationDbContext.Author'  is null.");
                }
                var author = await _context.Author.FindAsync(id);
                if (author != null)
                {
                    _context.Author.Remove(author);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool AuthorExists(int id)
            {
                return _context.Author.Any(e => e.AuthorId == id);
            }
        }
    }
