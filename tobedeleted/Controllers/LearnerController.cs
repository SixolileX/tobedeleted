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

        IAddLearnerTosub _IaddLearnerTosub;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

      

        public LearnerController( ApplicationDbContext db, IAddLearnerTosub addLearner, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            _db = db;
            _IaddLearnerTosub = addLearner;
            this._roleManager = roleManager;
            this._userManager = userManager;

        }
        [HttpGet]
        public IActionResult EnrollInSubjectAsync()
        {

            List<Subject> assigns = new List<Subject>();
            assigns = _db.Subjects.ToList();
            ViewBag.listofSubjects = assigns;
            


            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var ur = _db.UserRoles.ToList();
            var Sub = _db.Subjects.ToList();
            //ViewBag.Subjects = new SelectList(Sub, "SubID", "SubDesc");
       
            //ViewBag.listofSubjects = (from Ur in _db.UserRoles
            //                 join U in _db.Users on Ur.UserId equals U.Id
            //                 join R in _db.Roles on Ur.RoleId equals R.Id
            //                 where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Learner"
            //                 select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();
            return View();
        }
        //[HttpPost]
        //public async Task< IActionResult> EnrollInSubject(UserRole userRole, Subject subject,learners learners)
        //{


            //var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //ViewBag.Subjects = (from m in _db.learners
            //                    join A in _db.Subjects on m.UserlearnerId equals A.SubID
            //                    from E in _db.AssignSubject
            //                    join U in _db.Users on E.StudentID equals U.Id
            //                    where A.AssignedIdD == E.SujectID && E.StudentId == user
            //                    select new mySubject { AssignSubjectsVM = A, SubjectsVM = m, EnrollVM = E }).ToList();
            //assignSubject.StudentID = user;
            //assignSubject.SujectID = ID;
            //_db.AssignSubject.Add(assignSubject);
            //_db.SaveChanges();

            //var user = await _userManager.FindByIdAsync(userRole.UserId);

            //_IaddLearnerTosub.AddToLeanerAsync(learners, learners.SubjectName, learners.UserlearnerId);

            ////learners.SubjectName = user;
            ////learners.UserlearnerId = user;
            //_db.learners.Add(learners);
            //_db.SaveChanges();

            //return RedirectToAction(nameof(DashBoards));

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

            //Studentmaster studentmaster = new Studentmaster();
            //studentmaster.ListOfExams=( from obj in studentmaster.s)

            return View();
        }
        public ActionResult MarksCal()
        {


            return View();
        }


    }
}
