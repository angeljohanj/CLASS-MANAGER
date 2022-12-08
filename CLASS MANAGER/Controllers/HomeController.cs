using CLASS_MANAGER.Data;
using CLASS_MANAGER.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace CLASS_MANAGER.Controllers
{   
    public class HomeController : Controller
    {
        
        UsersData _userData = new UsersData();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles = "Teacher,Coordinator,Supervisor")]
        public IActionResult Index()
        {
            return View();
        }    

        public IActionResult Privacy()
        {
            return View();
        }

        ///============================THESE VIEWS ARE TO LIST, DELETE, EDIT TEACHERS===============================


        //=====================================To List Teachers=====================================================

        [Authorize(Roles = "Coordinator,Supervisor")]
        public IActionResult ListTeachers()
        {
            var teacherList = _userData.ListTeachers();

            return View(teacherList);
        }

        ///==================================== To Edit Teachers====================================================
        [Authorize(Roles = "Coordinator,Supervisor")]
        public IActionResult EditTeacher(int userID)
        {
            var user = _userData.GetUser(userID);        
            return View(user);
        }

        [HttpPost]
        public IActionResult EditTeacher(UserModel oUser)
        {
            var ans = _userData.EditTeacher(oUser);            
           
                if (ans)
                {
                    return RedirectToAction("ListTeachers", "Home");
                }
                else
                {
                    return View();
                }     

        }
        //==================================== To Soft-Delete a teacher=============================================
        [Authorize(Roles = "Coordinator,Supervisor")]
        public IActionResult DeleteTeacher(int userID)
        {
            var user = _userData.GetUser(userID);
            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteTeacher(UserModel oTeacher)
        {
            var ans = _userData.SoftDelete(oTeacher.UserID);

            if (ans)
            {
                return RedirectToAction("ListTeachers");

            }
            else
            {
                return View();
            }
        }

        //=============================================Coordinators=================================================
        [Authorize(Roles = "Supervisor")]
        public IActionResult ListCoordinators()
        {
            var coordiantor = _userData.ListCoordinators();
           return View(coordiantor);
        }

        //==============================================Errors======================================================

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}