using B.Tech.Repository;
using Microsoft.AspNetCore.Mvc;

namespace B.Tech.Controllers
{
    public class AdminController : Controller
    {
      ILogin _adminRepository;

        public AdminController(ILogin adminRepository)
        {
            _adminRepository = adminRepository;
        }

 
        public ActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (_adminRepository.Found(username, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }

     
        public ActionResult ResetPassword()
        {
            return View();
        }

    
        [HttpPost]
        public ActionResult ResetPassword(string OldPassword, string Newpassword)
        {
            if (_adminRepository.Reset(OldPassword, Newpassword))
            {
                ViewBag.Success = "Password has been reset successfully";
                return View();
            }
            else
            {
                ViewBag.Error = "Invalid password";
                return View();
            }
        }
    }
}
