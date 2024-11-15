using FootballWebProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballWebProject.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //для статистичного запису логіна та пароля
        private static readonly UserCredentials validUser = new UserCredentials
        {
            Username = "admin",
            Password = "password123"
        };

        [HttpPost]
        public IActionResult Login(UserCredentials userCredentials)
        {
            if (userCredentials.Username == validUser.Username && userCredentials.Password == validUser.Password)
            {
                return Redirect("https://localhost:7265/Teams");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неправильний логін або пароль!");
                return View(userCredentials);
            }
        }
    }
}
