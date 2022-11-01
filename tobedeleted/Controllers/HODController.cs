using tobedeleted.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using tobedeleted.Data;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using tobedeleted.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace tobedeleted.Controllers
{
    [Authorize(Roles = "HOD")]
    
    public class HODController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly ApplicationDbContext _db;
        ISubjectService _subjectService=null;
        IDepartmentService _departmentService=null;
        IAssignHOD _assignHOD;
        IAssignSubGrade _assignSubGrade;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HODController(IWebHostEnvironment webHostEnv, ApplicationDbContext db, ISubjectService subjectService, IDepartmentService departmentService, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IAssignHOD assignHOD, IAssignSubGrade assignSubGrade)
        {
            this._webHostEnv = webHostEnv;
            _db = db;
            _subjectService = subjectService;
            _departmentService = departmentService;
            this._roleManager = roleManager;
            this._userManager = userManager;
            _assignHOD = assignHOD;
            _assignSubGrade = assignSubGrade;
        }

        public IActionResult Dashboard()
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID==G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade=SG }).Distinct().ToList();


            return View();
        }
        
        public IActionResult CareerStream()
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();


            return View();
        }
        
        public IActionResult Grade()
        {
            
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            return View();
        }
        public IActionResult GetGrade()
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            IEnumerable<Grade> objList = _db.Grades;//Coming from our database
            return View(objList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Grade(Grade obj)
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();

            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Grades.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("GetGrade");
            }
            return View(obj);

        }
        public IActionResult UpdateGrade(int? id)
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            
            
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Grades.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpGet]
        public IActionResult AssignSubGr()
        {
            var grade = _db.Grades.Distinct().ToList();
            var subs = _db.Subjects.Distinct().ToList();
            var user = _userManager.Users.Distinct().ToList();
            var roles = _roleManager.Roles.Distinct().ToList();
            var ur = _db.UserRoles.Distinct().ToList();
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == users
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            ViewBag.Users = (from Ur in _db.UserRoles
                             join U in _db.Users on Ur.UserId equals U.Id
                             join R in _db.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Teacher"
                             select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).Distinct().ToList();
            ViewBag.Grades = new SelectList(grade, "GrID", "GrDesc").Distinct().ToList();
            ViewBag.Subjects = new SelectList(subs, "SubID", "SubDesc").Distinct().ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AssignSubGr(AssignSubjectGrade subGrade, UserRole userRole)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);
            subGrade = _assignSubGrade.AssignSubjectGradeAsync(subGrade, subGrade.GrID, subGrade.SubId, subGrade.userTeacher);
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            if (subGrade.SubGrID > 0)
            {
                OkResult result = Ok();
                return result;
            }
            else
            {
                Ok("Failed!");
                return RedirectToAction(nameof(AssignSubGr));
            }
            

        }
        public IActionResult ActivityLog()
        {
            ViewBag.HAttendance = (from UA in _db.UserActivities
                                  join U in _db.Users on UA.UserName equals U.UserName
                                  from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  from Ur in _db.UserRoles
                                  join u in _db.Users on Ur.UserId equals u.Id
                                  join R in _db.Roles on Ur.RoleId equals R.Id
                                  where R.Id == Ur.RoleId && U.Id==Ur.UserId && UA.UserName==U.UserName && H.DepID==D.DepID && R.Name=="HOD"
                                   select new HODactivityLog { Department=D, ApplicationUser=U}).Distinct().ToList();
            ViewBag.TAttendance = (from UA in _db.UserActivities
                                   join U in _db.Users on UA.UserName equals U.UserName
                                   from H in _db.HODs
                                   join D in _db.Departments on H.DepID equals D.DepID
                                   from Ur in _db.UserRoles
                                   join u in _db.Users on Ur.UserId equals u.Id
                                   join R in _db.Roles on Ur.RoleId equals R.Id
                                   where R.Id == Ur.RoleId && U.Id == Ur.UserId && UA.UserName == U.UserName && H.DepID == D.DepID && R.Name=="Teacher"
                                   select new HODactivityLog { Department = D, ApplicationUser = U }).Distinct().ToList();
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList(); 
            return View();
        }


            public IActionResult GetAssignedSubGr()
            {
                var grade = _db.Grades.Distinct().ToList();
                var subs = _db.Subjects.Distinct().ToList();
                var user = _userManager.Users.Distinct().ToList();
                var roles = _roleManager.Roles.Distinct().ToList();
                var uR = _db.UserRoles.Distinct().ToList();
                var ug = _assignSubGrade.AssignedSubGrades;
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                ViewBag.TeacherGrade = (from R in _db.Roles
                                        join UR in _db.UserRoles on R.Id equals UR.RoleId
                                        from S in _db.Subjects
                                        join SG in _db.SubsToGrade on S.SubID equals SG.SubId
                                        from G in _db.Grades
                                        join sg in _db.SubsToGrade on G.GrID equals sg.GrID
                                        from U in _db.Users
                                        join ur in _db.UserRoles on U.Id equals ur.UserId
                                        where U.Id == sg.userTeacher && ur.RoleId == R.Id && R.Name == "Teacher" && SG.GrID == G.GrID && SG.SubId == S.SubID
                                        select new AssignTeachersToGradeSubDisplay { Subject = S, Grade = G, applicationUser = U }).Distinct().ToList();
            //Coming from our database

            return View(ug);
            }

            //POST-Update updating the current data we have
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult UpdateGrade(Grade obj)
            {
                _db.Grades.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("GetGrade");
            }
            public IActionResult Subject()
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                ViewBag.Departments = _db.Departments.OrderBy(x => x.DepDesc).ToList();

                return View();
            }
            [HttpPost]
            public string SaveSubFile(UploadContent fileObj)
            {

                Subject oSubject = JsonConvert.DeserializeObject<Subject>(fileObj.Subject);
                ViewBag.Subjects = oSubject;
                if (fileObj.file.Length > 0)
                {

                    using (var ms = new MemoryStream())
                    {
                        fileObj.file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        oSubject.SubImage = fileBytes;//Here is the Subject photo in byte[] format

                        oSubject = _subjectService.Save(oSubject);
                        if (oSubject.SubID > 0)
                        {
                            return "Saved";
                        }
                    }
                }
                return "Failed";
            }

            [HttpGet]
            public JsonResult GetSavedSubject()
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                var sub = _subjectService.GetSavedSubject();
                sub.SubImage = this.GetImage(Convert.ToBase64String(sub.SubImage));
                return Json(sub);
            }

            private byte[] GetImage(string sBase64String)
            {
                byte[] bytes = null;
                if (!string.IsNullOrEmpty(sBase64String))
                {
                    bytes = Convert.FromBase64String(sBase64String);
                }
                return bytes;
            }

            public IActionResult UpdateSubject(int? id)
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (id == null || id == 0)
                {
                    return NotFound();
                }

                var obj = _db.Subjects.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }

                return View(obj);
            }

            //POST-Update updating the current data we have
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult UpdateSubject(Subject obj)
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _db.Subjects.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("GetSubject");
            }
            public IActionResult Department()
            {
                var grade = _db.Grades.Distinct().ToList();
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList(); ;
                ViewBag.Departments = _db.Departments.Distinct();
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult SaveDepartment(UploadContent fileObj)
            {

                Department oDepartment = JsonConvert.DeserializeObject<Department>(fileObj.Department);
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);

                using (var ms = new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oDepartment.DepPhoto = fileBytes;//Here is the Subject photo in byte[] format

                    oDepartment = _departmentService.Save(oDepartment);
                    if (oDepartment.DepID > 0)
                    {
                        return View(oDepartment);
                    }
                }
                if (ModelState.IsValid)//Checks to see if all the required fields have been met.
                {
                    _db.Departments.Add(oDepartment);
                    _db.SaveChanges();
                    return RedirectToAction("GetSubject");
                }
                return View(oDepartment);

            }
            [HttpPost]
            public string SaveFile(UploadContent fileObj)
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                Department oDepartment = JsonConvert.DeserializeObject<Department>(fileObj.Department);
                ViewBag.Departments = oDepartment;
                if (fileObj.file.Length > 0)
                {

                    using (var ms = new MemoryStream())
                    {
                        fileObj.file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        oDepartment.DepPhoto = fileBytes;//Here is the Subject photo in byte[] format

                        if (ModelState.IsValid)
                        {
                            oDepartment = _departmentService.Save(oDepartment);

                            if (oDepartment.DepID > 0)
                            {
                                return "Saved";
                            }
                        }

                    }
                }
                return "Failed";
            }

            [HttpGet]
            public JsonResult GetSavedDepartment()
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                var dep = _departmentService.SavedDepartment;
                dep.DepPhoto = this.GetImage(Convert.ToBase64String(dep.DepPhoto));
                return Json(dep);
            }

            public IActionResult GetDepartment()
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                IEnumerable<Department> objList = _db.Departments;//Coming from our database
                return View(objList);

            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Department(Department obj)
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                if (ModelState.IsValid)//Checks to see if all the required fields have been met.
                {
                    _db.Departments.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("GetDepartment");
                }
                return View(obj);

            }
            public IActionResult UpdateDepartment(int? id)
            {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == users
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            if (id == null || id == 0)
                {
                    return NotFound();
                }

                var obj = _db.Departments.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }

                return View(obj);
            }

            //POST-Update updating the current data we have
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult UpdateDepartment(UploadContent fileObj, Department obj)
            {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == users
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            obj = JsonConvert.DeserializeObject<Department>(fileObj.Department);
                if (fileObj.file.Length > 0)
                {

                    using (var ms = new MemoryStream())
                    {
                        fileObj.file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        obj.DepPhoto = fileBytes;//Here is the Subject photo in byte[] format

                        obj = _departmentService.Update(obj);
                    }
                    if (obj.DepID > 0)
                    {
                        return Ok("Saved");
                    }
                }
                return RedirectToAction("GetDepartment");
            }

            public IActionResult Meeting()
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                ViewBag.Today = DateTime.Today;

                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Meeting([Bind("MeetingID,SetDate,MeetingDate,Desc,userID")] MeetingScheduler meetingScheduler)
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);

                meetingScheduler.userID = users;
                ViewBag.User = meetingScheduler.userID.Distinct();
                if (ModelState.IsValid)
                {
                    _db.Add(meetingScheduler);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Meeting));
                }
                return View(meetingScheduler);

            }


            public IActionResult Reporting()
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                ViewBag.Report = (from H in _db.HODs
                              join D in _db.Departments on H.DepID equals D.DepID
                              join U in _db.Users on H.userHoDId equals U.Id
                              from S in _db.Subjects
                              join d in _db.Departments on S.DepID equals d.DepID
                              join z in _db.SubsToGrade on S.SubID equals z.SubGrID
                              from SG in _db.SubsToGrade
                              join G in _db.Grades on SG.GrID equals G.GrID
                              from M in _db.Marks
                              join s in _db.Subjects on M.SubID equals s.SubID
                              join A in _db.Assignment on M.AssignmentID equals A.AssignmentID
                              from m in _db.MeetingScheduler
                              join u in _db.Users on m.userID equals u.Id
                              from R in _db.Roles
                              join UR in _db.UserRoles on R.Id equals UR.RoleId
                              where D.DepID == H.DepID && S.DepID == H.DepID
                                    && SG.SubId == S.SubID && s.SubID == S.SubID && S.SubID == M.SubID && SG.GrID == G.GrID
                                    && H.userHoDId == U.Id && UR.UserId == U.Id && A.AssignmentID == M.AssignmentID
                              select new MyHODReport { Department = D, Subject = S, HODs = H, User = U, Grade = G, AssignSubjectGrade = SG, }).Distinct().ToList();
                return View();
            }

            [HttpGet]
            public IActionResult AddHODToSpecificDep()
            {
                var user = _userManager.Users.Distinct().ToList();
                var roles = _roleManager.Roles.Distinct().ToList();
                var ur = _db.UserRoles.Distinct().ToList();
                var deps = _db.Departments.Distinct().ToList();//assuming that enrolled departments will be add to List
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                ViewBag.Departments = new SelectList(deps, "DepID", "DepDesc").Distinct();

                ViewBag.Users = (from Ur in _db.UserRoles
                                 join U in _db.Users on Ur.UserId equals U.Id
                                 join R in _db.Roles on Ur.RoleId equals R.Id
                                 where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "HOD"
                                 select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).Distinct().ToList();
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> AddHODToSpecificDep(UserRole userRole, HODs HoD)
            {
                var user = await _userManager.FindByIdAsync(userRole.UserId);
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);

                HoD = _assignHOD.AddToHodAsync(HoD, HoD.userHoDId, HoD.DepID);
                if (HoD.HoDId > 0)
                {
                    return Ok();
                }
                return RedirectToAction(nameof(AddHODToSpecificDep));

            }
            public IActionResult TimeTable()
            {
                var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var deps = _db.Departments.Distinct().ToList();
                var subs = _db.Subjects.Distinct().ToList();
                var gr = _db.Grades.Distinct().ToList();
                var a = _db.Assignment.Distinct().ToList();
                ViewBag.Department = (from H in _db.HODs
                                      join D in _db.Departments on H.DepID equals D.DepID
                                      join U in _db.Users on H.userHoDId equals U.Id
                                      from S in _db.Subjects
                                      join d in _db.Departments on S.DepID equals d.DepID
                                      join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                      from SG in _db.SubsToGrade
                                      join G in _db.Grades on SG.GrID equals G.GrID
                                      from R in _db.Roles
                                      join UR in _db.UserRoles on R.Id equals UR.RoleId
                                      where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                      select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                ViewBag.Departments = new SelectList(deps, "DepID", "DepDesc").Distinct().ToList();
                ViewBag.Subjects = new SelectList(subs, "SubID", "SubDesc").Distinct().ToList();
                ViewBag.Grades = new SelectList(gr, "GrID", "GrDesc").Distinct().ToList();
                ViewBag.Assignment = new SelectList(a, "AssignmentID", "AssignmentTitle").Distinct().ToList();
                return View();
        }// GET: TimeTables
        public async Task<IActionResult> GetTimeTable()
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var deps = _db.Departments.Distinct().ToList();
            var subs = _db.Subjects.Distinct().ToList();
            var gr = _db.Grades.Distinct().ToList();
            var a = _db.Assignment.Distinct().ToList();
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            return View(await _db.TimetableDisplay.ToListAsync());
        }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> TimeTable([Bind("TtID,ExamDate,Date,Exam,DepID,Subject,GradeID")] TimeTable timeTable)
            {
                 var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
                 var deps = _db.Departments.Distinct().ToList();
                 var subs = _db.Subjects.Distinct().ToList();
                 var gr = _db.Grades.Distinct().ToList();
                 var a = _db.Assignment.Distinct().ToList();
                 ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
                 if (ModelState.IsValid)
                 {
                    _db.Add(timeTable);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Dashboard));
                 }
                 return View(timeTable);
            }
        // GET: TimeTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var deps = _db.Departments.Distinct().ToList();
            var subs = _db.Subjects.Distinct().ToList();
            var gr = _db.Grades.Distinct().ToList();
            var a = _db.Assignment.Distinct().ToList();
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _db.TimeTables.FindAsync(id);
            if (timeTable == null)
            {
                return NotFound();
            }
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TtID,ExamDate,Date,Exam,DepID,Subject,GradeID")] TimeTable timeTable)
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var deps = _db.Departments.Distinct().ToList();
            var subs = _db.Subjects.Distinct().ToList();
            var gr = _db.Grades.Distinct().ToList();
            var a = _db.Assignment.Distinct().ToList();
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            if (id != timeTable.TtID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(timeTable);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTableExists(timeTable.TtID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var deps = _db.Departments.Distinct().ToList();
            var subs = _db.Subjects.Distinct().ToList();
            var gr = _db.Grades.Distinct().ToList();
            var a = _db.Assignment.Distinct().ToList();
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = await _db.TimeTables
                .FirstOrDefaultAsync(m => m.TtID == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var deps = _db.Departments.Distinct().ToList();
            var subs = _db.Subjects.Distinct().ToList();
            var gr = _db.Grades.Distinct().ToList();
            var a = _db.Assignment.Distinct().ToList();
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            var timeTable = await _db.TimeTables.FindAsync(id);
            _db.TimeTables.Remove(timeTable);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool TimeTableExists(int id)
        {
            return _db.TimeTables.Any(e => e.TtID == id);
        }

        public IActionResult Announcement()
        {
            var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.Department = (from H in _db.HODs
                                  join D in _db.Departments on H.DepID equals D.DepID
                                  join U in _db.Users on H.userHoDId equals U.Id
                                  from S in _db.Subjects
                                  join d in _db.Departments on S.DepID equals d.DepID
                                  join A in _db.SubsToGrade on S.SubID equals A.SubGrID
                                  from SG in _db.SubsToGrade
                                  join G in _db.Grades on SG.GrID equals G.GrID
                                  from R in _db.Roles
                                  join UR in _db.UserRoles on R.Id equals UR.RoleId
                                  where d.DepID == H.DepID && S.DepID == H.DepID && SG.SubId == S.SubID && SG.GrID == G.GrID && H.userHoDId == users && UR.UserId == U.Id
                                  select new HodDisplay { Department = D, Subject = S, HOD = H, user = U, Grade = G, AssignSubjectGrade = SG }).Distinct().ToList();
            IEnumerable<Announcements> objList = _db.Announcements;
            return View(objList);
            
        }
    }
}
