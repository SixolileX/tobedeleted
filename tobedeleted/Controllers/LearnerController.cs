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
using Microsoft.AspNetCore.SignalR;


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
        public IActionResult EnrollInSubject()
        {

            List<Subject> assigns = new List<Subject>();
            assigns = _db.Subjects.ToList();
            ViewBag.listofSubjects = assigns;



            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var ur = _db.UserRoles.ToList();
            var Sub = _db.Subjects.ToList();





            ViewBag.users = (from Ur in _db.UserRoles
                             join U in _db.Users on Ur.UserId equals U.Id
                             join R in _db.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Learner"
                             select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();

            return View();

        }

        [TempData]
        public string ResponseMessage { get; set; }
        [HttpPost]
        public IActionResult EnrollInSubject(EnrollStudent enroll,int ID)
        {

            enroll.EnrollDate = DateTime.Today;
            enroll.SubjectID = ID;
            enroll.StudentID = User.FindFirstValue(ClaimTypes.NameIdentifier);


            _db.EnrollStudents.Add(enroll);

            _db.SaveChanges();

            ResponseMessage = "You Have sucess susscesfully Enrolled for" + enroll.SubjectID;

            //learners.SubjectName = user;
            //learners.UserlearnerId = user;


            return RedirectToAction(nameof(EnrollInSubject));

        }

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
        public ActionResult Resultss(string searching)
        {
            IEnumerable<StuMark> objList = _db.StuMarks;
            return View(_db.StuMarks.Where(x => x.LearnerIdUser.Contains(searching) || searching == null).ToList());

            
        }
        public ActionResult Maths()
        {


            return View();
        }
        public IActionResult Meetting()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Meetting(studentMeeting meet)
        {
           

            if (ModelState.IsValid)
            {
                _db.studentMeetings.Add(meet);
                _db.SaveChanges();
                return RedirectToAction("MeetingView");
            }


           
            
            return View(meet);
            
        }
        public ActionResult MeetingView()
        {

            IEnumerable<studentMeeting> Meets = _db.studentMeetings;
            return View(Meets);


        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calculator e)
        {


            e.Total = e.Term1 + e.Term2 + e.Term3 + e.Term4;
            e.avg = e.Total / 4;

            if (e.avg > 50)
            {
                e.Grade = "Pass";
            }
            else
            {
                e.Grade = "Fail";
            }

            return View(e);

        }



    }
}
