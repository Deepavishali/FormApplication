using DatabaseMigration.Models;
using DatabaseMigration.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Http.Headers;

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

        //ModelState checks every data inside the model is validated before saving them in database . It returns boolean

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Read");

            }
            return View(user);
        }

        //To get every data from the DB

        public IActionResult Read(int? searchId)
        {

            var usersQuery = _context.Users.AsQueryable();
            if(searchId.HasValue && searchId.Value > 0)
            {
                usersQuery = usersQuery.Where(u => u.Id == searchId.Value);
            }

            var data = usersQuery.ToList();
            return View(data);
        }

        //To get the data by id

        //public IActionResult ReadById(int id)
        //{
        //   var data =  _context.Users.Find(id);
        //    return View(data);
        //}

    }
}
