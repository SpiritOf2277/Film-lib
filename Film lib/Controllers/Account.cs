using Microsoft.AspNetCore.Mvc;
using Film_lib.Models;

namespace YourProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                // Add code to handle registration (e.g., save user to the database)
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid) {
                // Add code to handle login (e.g., validate user credentials)
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
