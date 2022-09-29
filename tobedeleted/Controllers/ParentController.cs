using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.Models;

namespace tobedeleted.Controllers
{
    [Authorize(Roles ="Parent")]
    public class ParentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ParentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<MeetingScheduler> objList = _db.MeetingScheduler;
            return View(objList);
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
