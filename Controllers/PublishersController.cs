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
using System.Security.Policy;
using Publisher = LibraryCodingNight.Models.Publisher;

namespace LibraryCodingNight.Controllers
{
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> UserManager;
        public PublishersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            UserManager = userManager;
        }
        // GET: Publishers
        public async Task<IActionResult> Index()
        {
            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(await _context.Publisher.ToListAsync());
            }
            else
                return NotFound();


        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publisher == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }

            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(publisher);
            }
            else
                return NotFound();
        }

        // GET: Publishers/Create
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

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,PhoneNumber")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(publisher);
            }
            else
                return NotFound();
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publisher == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }

            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(publisher);
            }
            else
                return NotFound();
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublisherId,PublisherName,PhoneNumber")] Publisher publisher)
        {
            if (id != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
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
                return View(publisher);
            }
            else
                return NotFound();
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publisher == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publisher
                .FirstOrDefaultAsync(m => m.PublisherId == id);
            if (publisher == null)
            {
                return NotFound();
            }


            var applicationUser = await UserManager.GetUserAsync(User);
            if (applicationUser.RoleId == 1)
            {
                return View(publisher);
            }
            else
                return NotFound();
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publisher == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Publisher'  is null.");
            }
            var publisher = await _context.Publisher.FindAsync(id);
            if (publisher != null)
            {
                _context.Publisher.Remove(publisher);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id)
        {
          return _context.Publisher.Any(e => e.PublisherId == id);
        }
    }
}
