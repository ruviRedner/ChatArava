using ChatArava.DAL;
using ChatArava.Models;
using Microsoft.AspNetCore.Mvc;


namespace ChatArava.Controllers
{
    public class LoginController : RegistrationController
    {
        //Get
        public IActionResult Index2()
        {
            return View();
        }
        //Get
       
        //Get
        public IActionResult LoginToChat(User user)
        {
            User? userFromDB = Data.Get.users.FirstOrDefault(u => u.userName == user.userName && u.password == user.password);
            if (userFromDB == null)
            {
                return NotFound();
            }
            Response.Cookies.Append("userName",user.userName);
            Response.Cookies.Append("password",user.password);
            return RedirectToAction("Index3","Chat");
        }
    }
}
