using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tobedeleted.Controllers
{
    [Authorize(Roles ="Parent")]
    public class ParentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Meeting()
        {
            return View();
        }
        public IActionResult AcademicProgress()
        {
            return View();
        }
        public IActionResult ActivityLog()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
    }
}
