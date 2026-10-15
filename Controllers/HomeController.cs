using DatabaseMigration.Models;
using DatabaseMigration.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseMigration.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return View();

            }
            return View(user);
        }

    }
}
