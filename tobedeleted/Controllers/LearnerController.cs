using tobedeleted.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Inn_TuneProject.Controllers
{
    public class LearnerController : Controller
    {
        

        private readonly ApplicationDbContext _db;
     
        public LearnerController( ApplicationDbContext db)
        {
            
            _db = db;
       
        }
        [HttpGet]
        public IActionResult EnrollInSubjectAsync()
        {

            List<Subject> assigns = new List<Subject>();
            assigns = _db.Subjects.ToList();
            ViewBag.listofSubjects = assigns;
            return View();

           
            
        }
        //[HttpPost]
        //public IActionResult EnrollInSubject(AssignSubject assignSubject, int ID)
        //{


        //    var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    ViewBag.Subjects = (from m in _db.Subjects
        //                        join A in _db.AssignSubject on m.SubID equals A.SubID
        //                        from E in _db.AssignSubject
        //                        join U in _db.Users on E.StudentID equals U.Id
        //                        where A.AssignedIdD == E.SujectID && E.StudentId == user
        //                        select new mySubject { AssignSubjectsVM = A, SubjectsVM = m, EnrollVM = E }).ToList();
        //    assignSubject.StudentID = user;
        //    assignSubject.SujectID = ID;
        //    _db.AssignSubject.Add(assignSubject);
        //    _db.SaveChanges();


        //    return RedirectToAction(nameof(DashBoards));

        //}

        public ActionResult DashBoards()
        {
            return View();
        }

        public ActionResult Subject()
        {
            return View();
        }
        public IActionResult GetSubject()
        {
            IEnumerable<Subject> objList = _db.Subjects;//Coming from our database
            return View(objList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subject(Subject obj)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Subjects.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("GetSubject");
            }
            return View(obj);

        }

        // GET: LearnerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LearnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LearnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LearnerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LearnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
  
        public ActionResult QUestionPA()
        {
            return View();
        }
        public ActionResult Report()
        {
            return View();
        }

    }
}
