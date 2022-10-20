using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.Models;

namespace tobedeleted.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        //public Reports reports = new Reports();
        private readonly ApplicationDbContext _db;
        private ApplicationDbContext applicationDbContext;

        //public TeacherController()
        //{
        //    applicationDbContext = new ApplicationDbContext();
        //}

        public TeacherController(IWebHostEnvironment webHostEnv, ApplicationDbContext db)
        {
            this._webHostEnv = webHostEnv;
            _db = db;
        }
        public IActionResult TDash()
        {
            var Assigns = _db.Assignment.ToList();
            return View(Assigns);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TDash(string seacrchText)
        {
            var Assigns = _db.Assignment.ToList();

            if(seacrchText != null)
            {
                Assigns = _db.Assignment.Where(x => x.AssignmentTitle.Contains(seacrchText)).ToList();
            }
            return View(Assigns);
        }
        public IActionResult Assessments()
        {
            return View();
        }
        public IActionResult Assignment()
        {
            return View("Assignment");
        }
        public IActionResult AddAssignment()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Assignment obj)
        {
            if (ModelState.IsValid)
            {
                _db.Assignment.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewAssignment");
            }
            return View(obj);

        }
        public IActionResult ViewAssignment()
        {
            IEnumerable<Assignment> objList = _db.Assignment;
            return View(objList);
        }

        public IActionResult Upload()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditAssignment(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var AssigninDb = _db.Assignment.FirstOrDefault(x => x.AssignmentID == id);
            if (AssigninDb == null)
                return NotFound();

            return View(AssigninDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAssignment(Assignment assignment)
        {
            if (!ModelState.IsValid)
                return View(assignment);

            _db.Assignment.Update(assignment);

            _db.SaveChanges();

            return RedirectToAction(nameof(ViewAssignment));
        }

        public async Task<IActionResult> DeleteAssignment(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var AssignInDb = _db.Assignment.FirstOrDefault(x => x.AssignmentID == id);

            if (AssignInDb == null)
                return NotFound();

            _db.Assignment.Remove(AssignInDb);

            _db.SaveChanges();

            return RedirectToAction(nameof(ViewAssignment));
        }

        
        public IActionResult AddAnouncements()
        {
            return View();

        }
        public IActionResult CreateAnnouncement()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnnouncement(Announcements obj)
        {
            if (ModelState.IsValid)
            {
                _db.Announcements.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ViewAnnouncements");
            }
            return View(obj);

        }
        public IActionResult ViewAnnouncements()
        {
            IEnumerable<Announcements> objList = _db.Announcements;
            return View(objList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnnouncements(Announcements announcements)
        {
            if (!ModelState.IsValid)
                return View(announcements);

            _db.Announcements.Update(announcements);

            _db.SaveChanges();

            return RedirectToAction(nameof(ViewAnnouncements));
        }
        public async Task<IActionResult> EditAnnouncements(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest();

            var AnnounceinDb = _db.Announcements.FirstOrDefault(x => x.AnnounceID == id);
            if (AnnounceinDb == null)
                return NotFound();

            return View(AnnounceinDb);
        }


        public IActionResult ViewAssessments()
        {
            return View();
        }
        public IActionResult Announcements()
        {
            return View();

        }
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult Quizz()
        {
            //Categories category = new Categories();
            //category.ListOfCategory = (from Cat in ApplicationDbContext.Categories
            //                           select new SelectListItem()
            //                           {

            //                               Value = Cat.CategoryId.ToString(),
            //                               Text = Cat.CategoryName
            //                           }).ToList();
            return View();
        }
        public IActionResult Meetings()
        {
            return View();
        }


    }
}
