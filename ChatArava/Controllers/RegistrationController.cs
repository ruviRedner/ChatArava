
using ChatArava.DAL;
using ChatArava.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatArava.Controllers
{
    public class RegistrationController : Controller
    {
        //Get
        public IActionResult Index1()
        {
            if (ValidateRequest(Request.Cookies))
            {
                return RedirectToAction("Index3","Chat");
            }
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CreateNew(User user)
        {
            Data.Get.users.Add(user);
            Data.Get.SaveChanges();

            return RedirectToAction("Index2","Login");
        }

        //Get
        public IActionResult Login()
        {
            return RedirectToAction("Index2", "Login");
        }
        //founction Of cookies
        public bool ValidateRequest(IRequestCookieCollection Cookies)
        {
            string? user_name = Cookies["userName"];
            string? password  = Cookies["Password"];

            if(user_name == null && password == null)
            {
                return false;
            }
            User? user = Data.Get.users.FirstOrDefault(u => u.userName == user_name && u.password == password);
            return user != null;
        }
    }
}
