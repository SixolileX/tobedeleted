using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        //private ApplicationDbContext applicationDbContext;

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
        public IActionResult AddAssignment()
        {
            return View();
        }
        public IActionResult ViewAssignment()
        {
            IEnumerable<Assignment> objList = _db.Assignment;
            return View(objList);
        }
        public IActionResult Create(Assignment obj)
        {
            if (ModelState.IsValid)
            {
                _db.Assignment.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Assessments");
            }
            return View(obj);


        }
        //public IActionResult GetAssignment()
        //{
        //    IEnumerable<Assignment> objList = _db.Assignments;//Coming from our database
        //    return View(objList);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Assignment(Assignment obj)
        //{
        //    if (ModelState.IsValid)//Checks to see if all the required fields have been met.
        //    {
        //        _db.Assignments.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("GetSubject");
        //    }
        //    return View(obj);

        //}
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
            //Category category = new Category();
            //category.ListofCategory = (from Cat in ApplicationDbContext.Categories
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
