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

namespace tobedeleted.Controllers
{
    [Authorize(Roles = "HOD")]
    public class HODController : Controller
    {
        //private const string V = "Save";
        private readonly IWebHostEnvironment _webHostEnv;
        //public Reports reports = new Reports();
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
            //var users = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Department = (from H in _db.HOD
            //                       join D in _db.Departments on H.DepID equals D.DepID
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from S in _db.Subjects
            //                       join d in _db.Departments on S.DepID equals d.DepID
            //                       join A in _db.SubsToGrade on S.SubID equals A.SubGrID
            //                       from SG in _db.SubsToGrade
            //                       join G in _db.Grades on SG.GrID equals G.GrID
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && S.SubID==H.DepID && H.userHoDId == users && UR.UserId == U.Id
            //                       select new HodDisplay { Department=D, Subject=S, HOD=H, user=U, Grade=G }).Distinct().ToList();


            return View();
        }

        //public IActionResult Dashboard()
        //{
        //    var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    ViewBag.Departments = (from s in _db.Subjects
        //                           join d in _db.Departments on s.DepID equals d.DepID
        //                           from H in _db.HOD
        //                           join U in _db.Users on H.UserId equals U.Id
        //                           from R in _db.Roles
        //                           join UR in _db.UserRoles on R.Id equals UR.RoleId
        //                           where d.DepID == H.DepID && H.UserId == user && UR.UserId == U.Id
        //                           select new )
        //}
        
        public IActionResult Grade()
        {
            //IEnumerable<Grade> objList = _db.Grades;//Coming from our database
            //return View(objList);
            return View();
        }
        public IActionResult GetGrade()
        {
            IEnumerable<Grade> objList = _db.Grades;//Coming from our database
            return View(objList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Grade(Grade obj)
        {
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
            var grade = _db.Grades.ToList();
            var subs = _db.Subjects.ToList();
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var ur = _db.UserRoles.ToList();
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Departments = (from s in _db.Subjects
            //                       join d in _db.Departments on s.DepID equals d.DepID
            //                       from H in _db.HOD
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && H.userHoDId == user && UR.UserId == U.Id
            //                       select new HodDisplay { }).ToList();
            ViewBag.Users = (from Ur in _db.UserRoles
                             join U in _db.Users on Ur.UserId equals U.Id
                             join R in _db.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Teacher"
                             select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();
            ViewBag.Grades = new SelectList(grade, "GrID", "GrDesc");
            ViewBag.Subjects = new SelectList(subs, "SubID", "SubDesc");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AssignSubGr(AssignSubjectGrade subGrade, UserRole userRole)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);
            subGrade = _assignSubGrade.AssignSubjectGradeAsync(subGrade, subGrade.GrID, subGrade.SubId, subGrade.userTeacher);
            //ViewBag.TeacherGrade = (from R in _db.Roles
            //                        join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                        from S in _db.Subjects
            //                        join SG in _db.SubsToGrade on S.SubID equals SG.SubId
            //                        from G in _db.Grades
            //                        join sg in _db.SubsToGrade on G.GrID equals sg.GrID
            //                        from U in _db.Users
            //                        join ur in _db.UserRoles on U.Id equals ur.UserId
            //                        where ur.UserId == U.Id && ur.RoleId == R.Id && R.Name == "Teacher"
            //                        select new AssignTeachersToGradeSubDisplay { Subject = S, Grade = G, applicationUser = U }).ToList();
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
        
        public IActionResult GetAssignedSubGr()
        {
            var grade = _db.Grades.ToList();
            var subs = _db.Subjects.ToList();
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var uR = _db.UserRoles.ToList();
            var ug = _assignSubGrade.AssignedSubGrades;
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Departments = (from s in _db.Subjects
            //                       join d in _db.Departments on s.DepID equals d.DepID
            //                       from H in _db.HOD
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && H.userHoDId == user && UR.UserId == U.Id
            //                       select new HodDisplay { }).ToList();
            ViewBag.TeacherGrade = (from R in _db.Roles
                                    join UR in _db.UserRoles on R.Id equals UR.RoleId
                                    from S in _db.Subjects
                                    join SG in _db.SubsToGrade on S.SubID equals SG.SubId
                                    from G in _db.Grades
                                    join sg in _db.SubsToGrade on G.GrID equals sg.GrID
                                    from U in _db.Users
                                    join ur in _db.UserRoles on U.Id equals ur.UserId
                                    where U.Id == sg.userTeacher && ur.RoleId == R.Id && R.Name == "Teacher"
                                    select new AssignTeachersToGradeSubDisplay { Subject = S, Grade = G, applicationUser = U }).ToList();//Coming from our database

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
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Departments = (from s in _db.Subjects
            //                       join d in _db.Departments on s.DepID equals d.DepID
            //                       from H in _db.HOD
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && H.userHoDId == user && UR.UserId == U.Id
            //                       select new HodDisplay { }).ToList();
            ViewBag.Department = _db.Departments.OrderBy(x => x.DepDesc).ToList();
            ViewBag.Subject = (from S in _db.Subjects
                               join D in _db.Departments on S.DepID equals D.DepID
                               where S.DepID == D.DepID
                               select new SubDep { Subject=S, Deptment = D}).ToList();
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
            _db.Subjects.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("GetSubject");
        }
        public IActionResult Department()
        {
            var grade = _db.Grades.ToList();
            var subs = _db.Subjects.ToList();
            ViewBag.Department = _db.Departments;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDepartment(UploadContent fileObj)
        {

            Department oDepartment = JsonConvert.DeserializeObject<Department>(fileObj.Department);
            //UploadContent upload = new UploadContent();
            //IFormFile file = Request.Form.Files.FirstOrDefault();
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
            //obj.SubImage = this.GetImage(Convert.ToBase64String(obj.SubImage));
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Departments.Add(oDepartment);
                _db.SaveChanges();
                return RedirectToAction("GetSubject");
            }
            return View(oDepartment);

        }
        [HttpPost]
        public string SaveFile(UploadContent fileObj, Department dep)
        {
            Department oDepartment = JsonConvert.DeserializeObject<Department>(fileObj.Department);
            ViewBag.Departments = oDepartment;
            if (fileObj.file.Length > 0)
            {

                using (var ms = new MemoryStream())
                {
                    fileObj.file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    oDepartment.DepPhoto = fileBytes;//Here is the Subject photo in byte[] format

                    oDepartment = _departmentService.Save(oDepartment);
                    if (oDepartment.DepID > 0)
                    {
                        return "Saved";
                    }
                }
            }
            return "Failed";
        }

        [HttpGet]
        public JsonResult GetSavedDepartment()
        {
            var dep = _departmentService.SavedDepartment;
            dep.DepPhoto = this.GetImage(Convert.ToBase64String(dep.DepPhoto));
            return Json(dep);
        }

        public IActionResult GetDepartment()
        {
            IEnumerable<Department> objList = _db.Departments;//Coming from our database
            return View(objList);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Department(Department obj)
        {
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
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Departments = (from s in _db.Subjects
            //                       join d in _db.Departments on s.DepID equals d.DepID
            //                       from H in _db.HOD
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && H.userHoDId == user && UR.UserId == U.Id
            //                       select new HodDisplay { }).ToList();
            ViewBag.Today = DateTime.Today;
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Meeting([Bind("MeetingID,SetDate,MeetingDate,Desc,userID")] MeetingScheduler meetingScheduler)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Departments = (from s in _db.Subjects
            //                       join d in _db.Departments on s.DepID equals d.DepID
            //                       from H in _db.HOD
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && H.userHoDId == user && UR.UserId == U.Id
            //                       select new HodDisplay { }).ToList();
            meetingScheduler.userID = user;
            ViewBag.User = meetingScheduler.userID;
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
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Departments = (from s in _db.Subjects
            //                       join d in _db.Departments on s.DepID equals d.DepID
            //                       from H in _db.HOD
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && H.userHoDId == user && UR.UserId == U.Id
            //                       select new HodDisplay { }).ToList();
            return View();
        }
        
        [HttpGet]
        public IActionResult AddHODToSpecificDep()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var ur = _db.UserRoles.ToList();
            var deps = _db.Departments.ToList();//assuming that enrolled departments will be add to List

            ViewBag.Department = new SelectList(deps, "DepID", "DepDesc");
           
            ViewBag.Users = (from Ur in _db.UserRoles
                             join U in _db.Users on Ur.UserId equals U.Id
                             join R in _db.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "HOD"
                             select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName=U.lastName }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHODToSpecificDep(UserRole userRole, Department department, HOD HoD)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);
            //var dep = await _assignHOD.FindByIdAsync(department.DepID);
            //await _userManager.AddToRoleAsync(user, userRole.RoleName);
            HoD= _assignHOD.AddToHodAsync(HoD, HoD.userHoDId, HoD.DepID);
            ViewBag.HoD = HoD;
            if (HoD.HoDId > 0)
            {
                return Ok("Saved");
            }
            return RedirectToAction(nameof(Dashboard));

        }
        public IActionResult TimeTable()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ViewBag.Departments = (from s in _db.Subjects
            //                       join d in _db.Departments on s.DepID equals d.DepID
            //                       from H in _db.HOD
            //                       join U in _db.Users on H.userHoDId equals U.Id
            //                       from R in _db.Roles
            //                       join UR in _db.UserRoles on R.Id equals UR.RoleId
            //                       where d.DepID == H.DepID && H.userHoDId == user && UR.UserId == U.Id
            //                       select new HodDisplay { }).ToList();
            return View();
        }
    }
}
