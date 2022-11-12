using Microsoft.AspNetCore.Mvc;
using CLASS_MANAGER.Data;
using CLASS_MANAGER.Models;
using CLASS_MANAGER.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace CLASS_MANAGER.Controllers
{
    public class UserMaintainerController : Controller
    {

        UsersData _userData = new UsersData();

        //---------Method only returns Login View Form---------------->>>>>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel oUser)
        {
            bool ans = _userData.ValidateUser(oUser);

            if (ans)
            {
               return RedirectToAction("Index","Home");
            }
            else
            {   
                
                return View();                
                
            }
        }
        
        

        public IActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Signup(UserModel oUser)
        {
            bool ans = _userData.SaveUser(oUser);

            if (ans)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();

            }
        }
    }
}
