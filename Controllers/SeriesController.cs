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
    public class SeriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public SeriesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(await _context.Serie.ToListAsync());
            }
            else
                return NotFound();



        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Serie == null)
            {
                return NotFound();
            }

            var serie = await _context.Serie
                .FirstOrDefaultAsync(m => m.SerieId == id);
            if (serie == null)
            {
                return NotFound();
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(serie);
            }
            else
                return NotFound();



        }

        // GET: Series/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SerieId,SerieName,SerieDescription")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(serie);
            }
            else
                return NotFound();

        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Serie == null)
            {
                return NotFound();
            }

            var serie = await _context.Serie.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(serie);
            }
            else
                return NotFound();

        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SerieId,SerieName,SerieDescription")] Serie serie)
        {
            if (id != serie.SerieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerieExists(serie.SerieId))
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
                return View(serie);
            }
            else
                return NotFound();

        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Serie == null)
            {
                return NotFound();
            }

            var serie = await _context.Serie
                .FirstOrDefaultAsync(m => m.SerieId == id);
            if (serie == null)
            {
                return NotFound();
            }
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(serie);
            }
            else
                return NotFound();

        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Serie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Serie'  is null.");
            }
            var serie = await _context.Serie.FindAsync(id);
            if (serie != null)
            {
                _context.Serie.Remove(serie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerieExists(int id)
        {
          return _context.Serie.Any(e => e.SerieId == id);
        }
    }
}
