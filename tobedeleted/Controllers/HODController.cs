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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HODController(IWebHostEnvironment webHostEnv, ApplicationDbContext db, ISubjectService subjectService, IDepartmentService departmentService, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IAssignHOD assignHOD)
        {
            this._webHostEnv = webHostEnv;
            _db = db;
            _subjectService = subjectService;
            _departmentService = departmentService;
            this._roleManager = roleManager;
            this._userManager = userManager;
            _assignHOD = assignHOD;
        }

        public IActionResult Dashboard()
        {
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
        //public IActionResult EnrolStaff()xsz
        //{
        //    //IEnumerable<User> objList = _db.Users;//Coming from our database
        //    //return View(objList);
        //    return View();
        //}
        //[HttpPost("Upload Content")]


        //[HttpPost("FileUpload")]
        //public async Task<IActionResult> FileUpload(List<IFormFile> files)
        //{
        //    var size = files.Sum(f => f.Length);
        //    var filePaths = new List<string>();
        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
        //            filePaths.Add(filePath);
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }
        //    return Ok(new { files.Count, size, filePaths });
        //}

        //POST-Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult EnrolStaff(User obj)
        //{
        //    if (ModelState.IsValid)//Checks to see if all the required fields have been met.
        //    {
        //        _db.Users.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Dashboard");
        //    }
        //    return View(obj);

        //}
        //public Reports reports = new Reports();

        //public IActionResult EnrolUser()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddSubDep(Subject sub, Department dep, SubDep subDep)
        //{
        //    var suDe = await SubDep.Equals(subDep)

        //    await userManager.AddToRoleAsync(user, userRole.RoleName);

        //    return RedirectToAction(nameof(Index));

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
            ViewBag.Department = _db.Departments.OrderBy(x => x.DepDesc).ToList();
            //ViewBag.Subject=_db.Subjects.
            return View();
        }
        [HttpPost]
        public string SaveSubFile(UploadContent fileObj, Subject sub)
        {
            Subject oSubject = JsonConvert.DeserializeObject<Subject>(fileObj.Subject);
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
        //public IActionResult GetSubject()
        //{
        //    IEnumerable<Subject> objList = _db.Subjects;//Coming from our database
        //    return View(objList);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Subject(UploadContent fileObj, Subject obj)
        //{

        //    obj = JsonConvert.DeserializeObject<Subject>(fileObj.Subject);
        //    UploadContent upload = new UploadContent();
        //    IFormFile file = Request.Form.Files.FirstOrDefault();
        //    using (var ms = new MemoryStream())
        //    {
        //        fileObj.Content.CopyTo(ms);
        //        var fileBytes = ms.ToArray();
        //        obj.SubImage = fileBytes;//Here is the Subject photo in byte[] format

        //        obj = _subjectService.Save(obj);
        //        if (obj.SubID > 0)
        //        {
        //            return RedirectToAction("GetSubject");
        //        }
        //    }
        //        //obj.SubImage = this.GetImage(Convert.ToBase64String(obj.SubImage));
        //        if (ModelState.IsValid)//Checks to see if all the required fields have been met.
        //    {
        //        _db.Subjects.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("GetSubject");
        //    }
        //    return View(obj);

        //}
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
            return View();
        }

        [HttpPost]
        public string SaveFile(UploadContent fileObj, Department dep)
        {
            Department oDepartment = JsonConvert.DeserializeObject<Department>(fileObj.Department);
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
        public IActionResult UpdateDepartment(Department obj)
        {
            _db.Departments.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("GetDepartment");
        }
        public IActionResult Role()
        {
            return View();
        }
        public IActionResult Meeting()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Meeting(Meeting obj)
        //{
        //    if (ModelState.IsValid)//Checks to see if all the required fields have been met.
        //    {
        //        _db.Meetings.Add(obj);
        //        _db.SaveChanges();
        //        return RedirectToAction("Meeting");
        //    }
        //    return View(obj);

        //}
        //public ActionResult Maths()
        //{
        //    return View();
        //}
        public IActionResult CareerStream()
        {
            return View();
        }

        //public IActionResult Commerce()
        //{
        //    return View();
        //}
        public IActionResult Reporting()
        {
            return View();
        }
        //public IActionResult ActivityLog()
        //{
        //    return View();
        //}
        public IActionResult Profile()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult AddHODToSpecificDep()
        {
            var users = _userManager.Users.ToList();
            var roles = _roleManager.Roles.ToList();
            var ur = _db.UserRoles.ToList();
            var deps = _db.Departments.ToList();//assuming that enrolled departments will be add to List

            //ViewBag.Users = new SelectList(users, "Id", "UserName");
            //ViewBag.Roles = new SelectList(roles, "Name", "Name");
            //ViewBag.UserRoles =;
            ViewBag.Department = new SelectList(deps, "DepID", "DepDesc");
            //ViewBag.HoDdisplay = (from R in _db.Roles
            //                      join Ur in _db.UserRoles on R.Id equals Ur.RoleId
            //                      join U in _db.Users on Ur.UserId equals U.Id
            //                      where Ur.RoleId==R.Id && R.Name== "HOD" && Ur.UserId == U.Id
            //                      select new UserRole { UserId = U.Id, RoleName=R.Name}).ToList();
            ViewBag.Users = (from Ur in _db.UserRoles
                             join U in _db.Users on Ur.UserId equals U.Id
                             join R in _db.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "HOD"
                             select new UserRole { UserId = U.Id, RoleName = R.Name }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHODToSpecificDep(UserRole userRole, Department department, HOD HoD)
        {
            var user = await _userManager.FindByIdAsync(userRole.UserId);
            //var dep = await _assignHOD.FindByIdAsync(department.DepID);
            await _userManager.AddToRoleAsync(user, userRole.RoleName);
             _assignHOD.AddToHodAsync(HoD, HoD.userHoDId, HoD.DepID);
            //if (HoD.HoDId > 0)
            //{
            //    return "Saved";
            //}
            return RedirectToAction(nameof(Dashboard));

        }
        //[HttpGet]
    }
}
