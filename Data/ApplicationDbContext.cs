using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryCodingNight.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser>? ApplicationUser { get; set; }
        public DbSet<ApplicationRole> ApplicationRole { get; set; }
        public DbSet<Book>? Book { get; set; }
        public DbSet<Author>? Author { get; set; }
        public DbSet<Serie>? Serie { get; set; }
        public DbSet<Publisher>? Publisher { get; set; }
        public DbSet<Genre>? Genre { get; set; }

        public DbSet<SuggestedBook>? SuggestedBook { get; set; }
        public DbSet<BorrowedBook>? BorrowedBook { get; set; }
        public DbSet<Reservation>? Reservation { get; set; }

    }
}