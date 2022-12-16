using System;
using System.Linq;
using System.Threading.Tasks;
using LibraryCodingNight.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace LibraryCodingNight.Data
{
    public static class SeedData
    {

        public static async Task InitializeAsync(
            IServiceProvider services)
        {
            var roleManager = services
                .GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services
                .GetRequiredService<UserManager<ApplicationUser>>();
            await EnsureTestAdminAsync(userManager);
        }
        private static async Task EnsureRolesAsync(
    RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager
                .RoleExistsAsync("Admin");

            if (alreadyExists) return;

            await roleManager.CreateAsync(
                new IdentityRole("Admin"));
        }
        private static async Task EnsureTestAdminAsync(
    UserManager<ApplicationUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.Email == "maksymilian.gala1@gmail.com")
                .SingleOrDefaultAsync();
            await userManager.AddToRoleAsync(
                testAdmin, "Admin");
        }
    }
}