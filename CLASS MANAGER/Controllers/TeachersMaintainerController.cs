using Microsoft.AspNetCore.Mvc;
using CLASS_MANAGER.Models;
using CLASS_MANAGER.Data;
namespace CLASS_MANAGER.Controllers
{
    public class TeachersMaintainerController : Controller
    {

        TeachersData _teacherData = new TeachersData();
        public IActionResult ListTeachers()
        {
            var oTeacher = _teacherData.ListTeacher();   
            return View(oTeacher);
        }
        public IActionResult SaveTeacher()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveTeacher(TeachersModel oTeacher)
        {
            bool ans = _teacherData.SaveTeacher(oTeacher);

            if (ans)
            {
                return RedirectToAction("ListTeachers");
            }
            else
            {
                return View();
            }

        }

        public IActionResult EditTeacher(int teacherID)
        {
            var oTeacher = _teacherData.GetTeacher(teacherID);

            return View(oTeacher);
        }

        [HttpPost]
        public IActionResult EditTeacher(TeachersModel oTeacher)
        {
            bool ans = _teacherData.EditTeacher(oTeacher);

            if (ans)
            {
                return RedirectToAction("ListTeachers");
            }
            else
            {
                return View();
            }
            
        }

        public  IActionResult DeleteTeacher(int teacherID)
        {
            var teacher = _teacherData.GetTeacher(teacherID);
            
            return View(teacher);
        }

        [HttpPost]
        public IActionResult DeleteTeacher(TeachersModel oteacher)
        {
            var ans = _teacherData.DeleteTeacher(oteacher.tchID);

            if (ans)
            {
                return RedirectToAction("ListTeachers");
            }
            else
            {
                return View();
            }
            
        }
        
    }
}
