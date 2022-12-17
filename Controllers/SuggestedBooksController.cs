using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryCodingNight.Data;
using LibraryCodingNight.Models;

namespace LibraryCodingNight.Controllers
{
    public class SuggestedBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuggestedBooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuggestedBooks
        public async Task<IActionResult> Index()
        {
              return View(await _context.SuggestedBook.ToListAsync());
        }

        // GET: SuggestedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SuggestedBook == null)
            {
                return NotFound();
            }

            var suggestedBook = await _context.SuggestedBook
                .FirstOrDefaultAsync(m => m.SuggestedBookId == id);
            if (suggestedBook == null)
            {
                return NotFound();
            }

            return View(suggestedBook);
        }

        // GET: SuggestedBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuggestedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuggestedBookId,SuggestedBookTitle,SuggesteBookAuthor")] SuggestedBook suggestedBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suggestedBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suggestedBook);
        }

        // GET: SuggestedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SuggestedBook == null)
            {
                return NotFound();
            }

            var suggestedBook = await _context.SuggestedBook.FindAsync(id);
            if (suggestedBook == null)
            {
                return NotFound();
            }
            return View(suggestedBook);
        }

        // POST: SuggestedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuggestedBookId,SuggestedBookTitle,SuggesteBookAuthor")] SuggestedBook suggestedBook)
        {
            if (id != suggestedBook.SuggestedBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suggestedBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuggestedBookExists(suggestedBook.SuggestedBookId))
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
            return View(suggestedBook);
        }

        // GET: SuggestedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SuggestedBook == null)
            {
                return NotFound();
            }

            var suggestedBook = await _context.SuggestedBook
                .FirstOrDefaultAsync(m => m.SuggestedBookId == id);
            if (suggestedBook == null)
            {
                return NotFound();
            }

            return View(suggestedBook);
        }

        // POST: SuggestedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SuggestedBook == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SuggestedBook'  is null.");
            }
            var suggestedBook = await _context.SuggestedBook.FindAsync(id);
            if (suggestedBook != null)
            {
                _context.SuggestedBook.Remove(suggestedBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuggestedBookExists(int id)
        {
          return _context.SuggestedBook.Any(e => e.SuggestedBookId == id);
        }
    }
}
