using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using tobedeleted.Data;
using tobedeleted.IService;
using tobedeleted.Models;

namespace tobedeleted.Controllers
{
    [Authorize(Roles ="Parent")]
    public class ParentController : Controller
    {
        ApplicationDbContext applicationDbContext;

        private readonly ApplicationDbContext _db;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        IAssignPTL assignPTL;
        public ParentController(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            applicationDbContext = new ApplicationDbContext();
            _db = db;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            IEnumerable<MeetingScheduler> objList = _db.MeetingScheduler;
            return View(objList);
        }
        [HttpGet]
        public IActionResult Meeting()
        {
            ViewBag.Userss = (from Ur in _db.UserRoles
                              join U in _db.Users on Ur.UserId equals U.Id
                              join R in _db.Roles on Ur.RoleId equals R.Id
                              where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Teacher"
                              select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Meetings(MeetingUser meetingUser)
        {
            
            //var user = await _userManager.FindByIdAsync(assign.userLearnerId);
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            meetingUser.userParent = user;

            _db.MeetingUser.Add(meetingUser);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MeetingScheduler obj)
        {
            if (ModelState.IsValid)
            {
                _db.MeetingScheduler.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Meeting");
            }
            return View(obj);


        }
        [HttpGet]
        public IActionResult AcademicProgress(string searching)
        {
            ViewBag.Assign = (from S in _db.StuMarks
                              join L in _db.Users on S.LearnerIdUser equals L.Id
                              from A in _db.AssignLearnerToParent
                              join l in _db.Users on A.userLearnerId equals l.Id
                              join P in _db.Users on A.userParent equals P.Id

                              where S.LearnerIdUser == L.Id && A.userParent == l.Id
                              select new StuMark { });

            IEnumerable<StuMark> objList = _db.StuMarks;
            return View(_db.StuMarks.Where(x => x.LearnerIdUser.Contains(searching) || searching == null).ToList());

       
        }
        public async Task<IActionResult> TimeTable()
        {
            return View(await _db.TimeTables.ToListAsync());
        }
        public IActionResult ActivityLog()
        {
            IEnumerable<Announcements> objList = _db.Announcements;
            return View(objList);
            //return View();
        }
        public IActionResult Report()
        {
            //var Info = from P in _db.Parent
            //           join l in _db.Learner on P.Parentid equals l.Parentid


            //           where P.Parentid == l.Parentid

            //           select new DisplayLearnerInfo { }

            return View();
        }
        [HttpGet]
        public IActionResult AssignParentToLearner()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var ur = _db.UserRoles.ToList();




            ViewBag.Users = (from Ur in _db.UserRoles
                             join U in _db.Users on Ur.UserId equals U.Id
                             join R in _db.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Parent"
                             select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();

            ViewBag.Userss = (from Ur in _db.UserRoles
                              join U in _db.Users on Ur.UserId equals U.Id
                              join R in _db.Roles on Ur.RoleId equals R.Id
                              where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Learner"
                              select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AssignParentToLearner(AssignLearnerToParent assign)
        {
            //var user = await _userManager.FindByIdAsync(assign.userLearnerId);
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            assign.userParent = user;

            _db.AssignLearnerToParent.Add(assign);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        //[HttpPost]
        //public async Task<IActionResult> AssignParentToLearner(UserRole userRole, Parent parent, Learner learner)
        //{
        //    var user = await _userManager.FindByIdAsync(userRole.UserId);
        //    //var dep = await _assignHOD.FindByIdAsync(department.DepID);
        //    //await _userManager.AddToRoleAsync(user, userRole.RoleName);
        //    assignPTL.AddToParentAsync(parent, parent.userParentId, parent.userLearnerId);
        //    //if (HoD.HoDId > 0)
        //    //{
        //    //    return "Saved";
        //    //}
        //    return RedirectToAction(nameof(Index));

        //}
    }
}
