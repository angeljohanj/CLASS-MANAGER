using Microsoft.AspNetCore.Mvc;
using CLASS_MANAGER.Data;
using CLASS_MANAGER.Models;
using CLASS_MANAGER.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


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
        public async Task<IActionResult> Login(UserModel oUser)
        {
            var isUser = _userData.ValidateUser(oUser);
            
                if (isUser != null) {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, isUser.UserName),
                    new Claim("Email", isUser.Email)
                };

                foreach (var rol in isUser.UserRole)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol.ToString()));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));


                    return RedirectToAction("Index", "Home");
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
                return RedirectToAction("Login", "UserMaintainer");
            }
            else
            {
                return View();

            }
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "UserMaintainer");
        }
    }
}
