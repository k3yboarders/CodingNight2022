using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryCodingNight.Controllers
{
    [Authorize(Policy = "RequireStudentRole")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
