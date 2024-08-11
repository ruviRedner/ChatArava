using ChatArava.DAL;
using ChatArava.Models;
using ChatArava.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatArava.Controllers
{
    public class ChatController : RegistrationController
    {
        //Get
        public IActionResult Index3()
        {
            if (!ValidateRequest(Request.Cookies))
            {
                return RedirectToAction("Index2","Login");
            }
            ChatView chatView = new ChatView()
            {
                Messages = Data.Get.messagess.Include(u => u.sender).ToList(),
                Message = new Message()


            };
             
             return View(chatView);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult SendMessage(ChatView chatView)
        {
            if (!ValidateRequest(Request.Cookies))
            {
                return RedirectToAction("Index2", "Login");
            }

            User? user = Data.Get.users
                .FirstOrDefault(u => u.userName == Request.Cookies["userName"]);

            chatView.Message.timeStentd = DateTime.Now;
            chatView.Message.sender = user;
            user.MessagessesList.Add(chatView.Message);
            Data.Get.messagess.Add(chatView.Message);
            Data.Get.SaveChanges();
            return RedirectToAction("Index3");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("userName");
            Response.Cookies.Delete("password");
            return RedirectToAction("Index2", "Login");
        }
    }
}
