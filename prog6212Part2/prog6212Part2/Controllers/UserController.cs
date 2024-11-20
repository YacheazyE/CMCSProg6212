using Microsoft.AspNetCore.Mvc;
using prog6212Part2.Models;
using System.Linq;

namespace prog6212Part2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(string email, string password)
        //{
        //    // Query the UserContext to check if a user with matching email and password exists
        //    var user = _context.Users
        //        .FirstOrDefault(u => u.Email == email && u.Password == password);

        //    if (user != null)
        //    {
        //        // User exists, login successful
        //        ViewBag.Message = "Login successful!";
        //        // You might also want to set a session or redirect to a secure area
        //        return RedirectToAction("Index"); // Redirect to the Index or another view
        //    }
        //    else
        //    {
        //        // User not found, login failed
        //        ViewBag.Message = "Invalid email or password.";
        //        return View();
        //    }
        //}

        public IActionResult Register()
        {
            return View();
        } 
        
        public IActionResult Login()
        {
            return View();
        }
    }
}
