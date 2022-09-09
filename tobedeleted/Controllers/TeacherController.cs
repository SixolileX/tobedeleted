using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult TDash()
        {
            return View();
        }
        public IActionResult Assessments()
        {
            return View();
        }
        public IActionResult Assignment()
        {
            return View("Assignment");
        }
        public IActionResult Announcements()
        {
            return View();

        }
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Quizz()
        {
            return View();
        }

    }
}
