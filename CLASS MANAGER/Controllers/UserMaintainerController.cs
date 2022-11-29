using Microsoft.AspNetCore.Mvc;
using CLASS_MANAGER.Data;
using CLASS_MANAGER.Models;
using CLASS_MANAGER.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

//----------For authentication and claims--------->>>
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


namespace CLASS_MANAGER.Controllers
{
    public class UserMaintainerController : Controller
    {

        UsersData _userData = new UsersData();

        ///=========================THESE VIEWS ARE FOR THE LOGIN, NEW USER AND SIGNOUT=========>>>>>>>>>>>>>


        //---------Method only returns Login View Form---------------->>>>>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel oUser)
        {
            var isUser = _userData.ValidateUser(oUser);
                
                if (isUser != null && isUser.UserID!=0) {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, isUser.UserName),
                    new Claim("Email", isUser.Email),
                    new Claim(ClaimTypes.Role, isUser.UserRole)
                };

                /*foreach (var role in isUser.UserRole)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }*/

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                 
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));


                    return RedirectToAction("Index", "Home");
                }
                else
                {   
                    return View();
                }            
        }     
        

        public IActionResult NewUser()
        {

            return View();
        }


        [HttpPost]
        public IActionResult NewUser(UserModel oUser)
        {
            if (oUser.UserName == null || oUser.UserPassword == null || oUser.Name == null || oUser.Lastname == null
                || oUser.Age == null || oUser.Cedula == null || oUser.Address == null || oUser.Telephone == null
                || oUser.Email == null)
            {
                return View();
            }
            else
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
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "UserMaintainer");
        }        
    }      
}
