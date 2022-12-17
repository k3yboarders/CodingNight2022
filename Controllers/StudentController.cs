﻿using LibraryCodingNight.Data;
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

            var applicationDbContext = _context.Book.Include(b => b.Genre).Include(b => b.Serie).Include(b => b.Publisher).Include(b => b.Author);
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
                        break;             
                    case 3:
                        books = books.Where(b => b.ISBN!.Contains(searchString));
                        ViewBag.SelectedItem = 3;
                        break;                   
                    case 4:
                        books = books.Where(b => b.Genre.GenreName!.Contains(searchString));
                        ViewBag.SelectedItem = 4;
                        break;      
                    case 5:
                        books = books.Where(b => b.Serie.SerieName!.Contains(searchString));
                        ViewBag.SelectedItem = 5;
                        break;
                    default:
                        books = books.Where(b => b.Title!.Contains(searchString));
                        ViewBag.SelectedItem = 1;
                        break;
                }

            }

            return View(await books.ToListAsync());
        }
    }
    
}
