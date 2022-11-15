using Microsoft.AspNetCore.Mvc;
using CLASS_MANAGER.Data;
using CLASS_MANAGER.Models;
using Microsoft.AspNetCore.Authorization;

namespace CLASS_MANAGER.Controllers { 

    [Authorize]
    public class StudentMaintainerController : Controller
    {
        StudentsData _studentsData = new StudentsData();
        public IActionResult ListStu()
        {
            var oListStu = _studentsData.StuList();
            return View(oListStu);
        }

        //-----------------------Only returns view------------>
        public IActionResult SaveStu()
        {
            return View();
        }

        //----------------------Saves Students---------------->
        [HttpPost]
        public IActionResult SaveStu(StudentsModel Stu)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var ans = _studentsData.SaveStu(Stu);

            if (ans)
            {
                return RedirectToAction("ListStu");
            }
            else
            {
                return View();

            }
         }

        public IActionResult EditStu(int studentID)
        {
            var student = _studentsData.GetStu(studentID);
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStu(StudentsModel oStu)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var ans = _studentsData.EditStu(oStu);

            if (ans)
            {
                return RedirectToAction("ListStu");
            }
            else
            {
                return View();

            }
        }

        public IActionResult DelStu(int studentID)
        {
            var oStu = _studentsData.GetStu(studentID);
            return View(oStu);
        }
        
        [HttpPost]
        public IActionResult DelStu(StudentsModel oStu)
        {
            var ans = _studentsData.StuDel(oStu.StudentID);

            if (ans)
            {
                return RedirectToAction("ListStu");
            }
            else
            {
                return View();
            }

            
        }

    }
}
